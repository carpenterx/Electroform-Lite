using ElectroformLite.Application.DataGroups.Commands.CreateDataGroup;
using ElectroformLite.Application.DataGroups.Queries.GetDataGroupsByType;
using ElectroformLite.Application.DataGroups.Queries.GetDataGroupsList;
using ElectroformLite.Application.DataGroupTemplates.Commands.CreateDataGroupTemplate;
using ElectroformLite.Application.DataGroupTemplates.Queries.GetDataGroupTemplate;
using ElectroformLite.Application.DataGroupTemplates.Queries.GetDataGroupTemplatesList;
using ElectroformLite.Application.DataGroupTypes.Commands.CreateDataGroupType;
using ElectroformLite.Application.DataGroupTypes.Queries.GetDataGroupType;
using ElectroformLite.Application.DataGroupTypes.Queries.GetDataGroupTypesList;
using ElectroformLite.Application.DataTemplates.Commands.CreateDataTemplate;
using ElectroformLite.Application.DataTemplates.Queries.GetDataTemplate;
using ElectroformLite.Application.DataTemplates.Queries.GetDataTemplatesList;
using ElectroformLite.Application.DataTypes.Commands.CreateDataType;
using ElectroformLite.Application.DataTypes.Queries.GetDataTypesList;
using ElectroformLite.Application.Documents.Commands.CreateDocument;
using ElectroformLite.Application.Documents.Queries.GetDocuments;
using ElectroformLite.Application.Templates.Commands.CreateTemplateCommand;
using ElectroformLite.Application.Templates.Queries.GetTemplates;
using ElectroformLite.Application.UserData.Commands.CreateData;
using ElectroformLite.Application.UserData.Queries.GetDataList;
using ElectroformLite.Application.Users.Queries.GetUser;
using ElectroformLite.ClassDiagram;
using ElectroformLite.Domain.Models;
using MediatR;
using System.Reflection;

namespace ElectroformLite.ConsolePresentation;

public class ApplicationManager
{
    List<DataType> dataTypes = new();
    List<DataTemplate> dataTemplates = new();
    List<Data> dataList = new();

    List<DataGroupType> dataGroupTypes = new();
    List<DataGroupTemplate> dataGroupTemplates = new();
    List<DataGroup> dataGroups = new();

    List<Template> templates = new();
    List<Document> documents = new();

    User user = new();

    int cerereTemplateId;

    readonly IMediator _mediator;

    public ApplicationManager(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async void StartApplication()
    {
        /*user = await _mediator.Send(new GetUserQuery(0));*/

        await PopulateTemplates();

        await DisplayCommandsMenu();
    }

    async Task PopulateTemplates()
    {
        int textTypeId = await _mediator.Send(new CreateDataTypeCommand("Text"));
        int phoneTypeId = await _mediator.Send(new CreateDataTypeCommand("Phone"));
        int emailTypeId = await _mediator.Send(new CreateDataTypeCommand("Email"));

        int firstNameId = await _mediator.Send(new CreateDataTemplateCommand("FirstName", textTypeId));
        int lastNameId = await _mediator.Send(new CreateDataTemplateCommand("LastName", textTypeId));
        int emailId = await _mediator.Send(new CreateDataTemplateCommand("Email", emailTypeId));
        int phoneId = await _mediator.Send(new CreateDataTemplateCommand("PhoneNumber", phoneTypeId));

        List<int> personDataTemplates = new() { firstNameId, lastNameId };
        List<int> contactDataTemplates = new() { emailId, phoneId };

        int personTypeId = await _mediator.Send(new CreateDataGroupTypeCommand("Person"));
        int contactTypeId = await _mediator.Send(new CreateDataGroupTypeCommand("Contact"));

        int personDataGroupTemplateId = await _mediator.Send(new CreateDataGroupTemplateCommand("Person", personTypeId, personDataTemplates));
        int contactDataGroupTemplateId = await _mediator.Send(new CreateDataGroupTemplateCommand("Contact", contactTypeId, contactDataTemplates));
        List<int> dataGroupTemplates = new() { personDataGroupTemplateId, contactDataGroupTemplateId };

        string templateName = "Template for Cerere Alocare Credentiale Pentru Plata Impozitelor Si Taxelor Locale Pentru Persoane Fizice";
        string templateContent = @"Subsemnatul/a [Person.FirstName] [Person.LastName], e-mail [Contact.Email], numar de
telefon [Contact.PhoneNumber], solicit a-mi fi atribuit credential in
vederea platii prin www.ghiseul.ro
	- Sunt de acord ca orice corespondenta sa fie expediata doar pe adresa
de e-mail mai sus mentionata sau telefonic;
	- Ridicarea credentialului se va face personal sau prin mandatar, daca
nu este comunicat la adresa de e-mail mai sus mentionata;
	- Plata se va efectua doar prin intermediul unui card bancar;
	- Atasez la prezenta cerere, copie a actului de identitate a numitului/ei
[Person.FirstName] [Person.LastName]

Data {DateTime.Today}							Semnatura";

        cerereTemplateId = await _mediator.Send(new CreateTemplateCommand(templateName, templateContent, dataGroupTemplates));
    }

    async Task GenerateDocument(int templateId)
    {
        // get template
        Template template = await _mediator.Send(new GetTemplateQuery(templateId));
        string documentContent = template.Content;

        List<int> dataGroupIds = new();
        // get each data group template
        foreach (int dataGroupTemplateId in template.DataGroupTemplates)
        {
            DataGroupTemplate dataGroupTemplate = await _mediator.Send(new GetDataGroupTemplateQuery(dataGroupTemplateId));
            List<DataGroup> sameTypeDataGroups = await _mediator.Send(new GetDataGroupsByTypeQuery(dataGroupTemplate.Type));
            foreach (DataGroup sameDataGroup in sameTypeDataGroups)
            {
                Console.WriteLine($"{sameDataGroup.Id} {sameDataGroup.Name}");
            }
            DataGroupType dataGroupType = await _mediator.Send(new GetDataGroupTypeQuery(dataGroupTemplate.Type));

            Console.WriteLine($"{dataGroupTemplate.Name} data group name:");
            string dataGroupName = Console.ReadLine();

            List<int> dataIds = new();
            // get each data template
            foreach (int dataTemplateId in dataGroupTemplate.DataTemplates)
            {
                // generate each data
                DataTemplate dataTemplate = await _mediator.Send(new GetDataTemplateQuery(dataTemplateId));
                Console.WriteLine($"{dataTemplate.Placeholder}:");
                string dataValue = Console.ReadLine();
                Data data = new(dataTemplate, dataValue);
                int dataId = await _mediator.Send(new CreateDataCommand(data));
                dataIds.Add(dataId);
                documentContent = documentContent.Replace($"[{dataGroupType.Value}.{data.Placeholder}]",data.Value);
            }
            // generate each data group
            DataGroup dataGroup = new(dataGroupTemplate, dataGroupName, dataIds);
            int dataGroupId = await _mediator.Send(new CreateDataGroupCommand(dataGroup));
            dataGroupIds.Add(dataGroupId);
        }
        // generate document
        Console.WriteLine("Document name:");
        string documentName = Console.ReadLine();
        Document document = new(documentName, documentContent, templateId, dataGroupIds);
        await _mediator.Send(new CreateDocumentCommand(document));
        DisplayDocument(document);
    }

    async Task DisplayCommandsMenu()
    {
        DisplayCommandsHint();

        ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);

        Console.Clear();
        switch (consoleKeyInfo.Key)
        {
            case ConsoleKey.D1:
                //CreateDataGroups();
                await DisplayCommandsMenu();
                break;
            case ConsoleKey.D2:
                await CreateDocument();
                break;
            case ConsoleKey.D3:
                await DisplayUserData();
                break;
            case ConsoleKey.D4:
                await DisplayTemplateData();
                break;
            default:
                await DisplayCommandsMenu();
                break;
        }
    }

    static void DisplayCommandsHint()
    {
        const int menuWidth = 40;
        string line = new('-', menuWidth);

        Console.WriteLine($"+{line}+");
        Console.WriteLine($"|{"Commands:",-menuWidth}|");
        Console.WriteLine($"+{line}+");
        Console.WriteLine($"|{"(1) Create data groups",-menuWidth}|");
        Console.WriteLine($"|{"(2) Create document",-menuWidth}|");
        Console.WriteLine($"|{"(3) Display User Data",-menuWidth}|");
        Console.WriteLine($"|{"(4) Display Template Data",-menuWidth}|");
        Console.WriteLine($"+{line}+");
    }

    async Task CreateDocument()
    {
        await GenerateDocument(cerereTemplateId);

        await DisplayData();
        await DisplayDataGroups();
        await DisplayDocuments();
        await DisplayCommandsMenu();
    }

    async Task DisplayUserData()
    {
        await DisplayDocuments();
        await DisplayDataGroups();
        await DisplayData();
        await DisplayCommandsMenu();
    }

    async Task DisplayTemplateData()
    {
        await DisplayTemplates();
        await DisplayDataGroupTemplates();
        await DisplayDataGroupTypes();
        await DisplayDataTemplates();
        await DisplayDataTypes();
        await DisplayCommandsMenu();
    }

    async Task DisplayTemplates()
    {
        templates = await _mediator.Send(new GetTemplatesQuery());
        const int cellWidth = -20;
        string line = new('-', 41);
        Console.WriteLine($"+{line}+");
        Console.WriteLine($"|{"TEMPLATES",-41}|");
        Console.WriteLine($"+{line}+");
        if (templates.Count > 0)
        {
            Console.WriteLine($"|{"Id",cellWidth}|{"Name",cellWidth}|");
            Console.WriteLine($"+{line}+");
            foreach (Template template in templates)
            {
                Console.WriteLine($"|{template.Id,cellWidth}|{template.Name,cellWidth}|");
            }
            Console.WriteLine($"+{line}+");
        }
        Console.WriteLine();
    }

    async Task DisplayDataGroupTemplates()
    {
        dataGroupTemplates = await _mediator.Send(new GetDataGroupTemplatesListQuery());
        const int cellWidth = -20;
        string line = new('-', 62);
        Console.WriteLine($"+{line}+");
        Console.WriteLine($"|{"DATA GROUP TEMPLATES",-62}|");
        Console.WriteLine($"+{line}+");
        if (dataGroupTemplates.Count > 0)
        {
            Console.WriteLine($"|{"Id",cellWidth}|{"Name",cellWidth}|{"Type",cellWidth}|");
            Console.WriteLine($"+{line}+");
            foreach (DataGroupTemplate dataGroupTemplate in dataGroupTemplates)
            {
                Console.WriteLine($"|{dataGroupTemplate.Id,cellWidth}|{dataGroupTemplate.Name,cellWidth}|{dataGroupTemplate.Type,cellWidth}|");
            }
            Console.WriteLine($"+{line}+");
        }
        Console.WriteLine();
    }

    async Task DisplayDataGroupTypes()
    {
        dataGroupTypes = await _mediator.Send(new GetDataGroupTypesListQuery());
        const int cellWidth = -20;
        string line = new('-', 41);
        Console.WriteLine($"+{line}+");
        Console.WriteLine($"|{"DATA GROUP TYPES",-41}|");
        Console.WriteLine($"+{line}+");
        if (dataGroupTypes.Count > 0)
        {
            Console.WriteLine($"|{"Id",cellWidth}|{"Value",cellWidth}|");
            Console.WriteLine($"+{line}+");
            foreach (DataGroupType dataGroupType in dataGroupTypes)
            {
                Console.WriteLine($"|{dataGroupType.Id,cellWidth}|{dataGroupType.Value,cellWidth}|");
            }
            Console.WriteLine($"+{line}+");
        }
        Console.WriteLine();
    }

    async Task DisplayDataTemplates()
    {
        dataTemplates = await _mediator.Send(new GetDataTemplatesListQuery());
        const int cellWidth = -20;
        string line = new('-', 62);
        Console.WriteLine($"+{line}+");
        Console.WriteLine($"|{"DATA TEMPLATES",-62}|");
        Console.WriteLine($"+{line}+");
        if (dataTemplates.Count > 0)
        {
            Console.WriteLine($"|{"Id",cellWidth}|{"Placeholder",cellWidth}|{"Type",cellWidth}|");
            Console.WriteLine($"+{line}+");
            foreach (DataTemplate dataTemplate in dataTemplates)
            {
                Console.WriteLine($"|{dataTemplate.Id,cellWidth}|{dataTemplate.Placeholder,cellWidth}|{dataTemplate.Type,cellWidth}|");
            }
            Console.WriteLine($"+{line}+");
        }
        Console.WriteLine();
    }

    async Task DisplayDataTypes()
    {
        dataTypes = await _mediator.Send(new GetDataTypesListQuery());
        const int cellWidth = -20;
        string line = new('-', 41);
        Console.WriteLine($"+{line}+");
        Console.WriteLine($"|{"DATA TYPES",-41}|");
        Console.WriteLine($"+{line}+");
        if (dataTypes.Count > 0)
        {
            Console.WriteLine($"|{"Id",cellWidth}|{"Value",cellWidth}|");
            Console.WriteLine($"+{line}+");
            foreach (DataType dataType in dataTypes)
            {
                Console.WriteLine($"|{dataType.Id,cellWidth}|{dataType.Value,cellWidth}|");
            }
            Console.WriteLine($"+{line}+");
        }
        Console.WriteLine();
    }

    async Task DisplayDocuments()
    {
        documents = await _mediator.Send(new GetDocumentsQuery());
        const int cellWidth = -20;
        string line = new('-', 62);
        Console.WriteLine($"+{line}+");
        Console.WriteLine($"|{"DOCUMENTS",-62}|");
        Console.WriteLine($"+{line}+");
        if (documents.Count > 0)
        {
            Console.WriteLine($"|{"Id",cellWidth}|{"Name",cellWidth}|{"TemplateId",cellWidth}|");
            Console.WriteLine($"+{line}+");
            foreach (Document document in documents)
            {
                Console.WriteLine($"|{document.Id,cellWidth}|{document.Name,cellWidth}|{document.TemplateId,cellWidth}|");
            }
            Console.WriteLine($"+{line}+");
        }
        Console.WriteLine();
    }

    async Task DisplayDataGroups()
    {
        dataGroups = await _mediator.Send(new GetDataGroupsListQuery());
        const int cellWidth = -20;
        string line = new('-', 62);
        Console.WriteLine($"+{line}+");
        Console.WriteLine($"|{"DATA GROUPS",-62}|");
        Console.WriteLine($"+{line}+");
        if (dataGroups.Count > 0)
        {
            Console.WriteLine($"|{"Id",cellWidth}|{"Name",cellWidth}|{"Type",cellWidth}|");
            Console.WriteLine($"+{line}+");
            foreach (DataGroup dataGroup in dataGroups)
            {
                Console.WriteLine($"|{dataGroup.Id,cellWidth}|{dataGroup.Name,cellWidth}|{dataGroup.Type,cellWidth}|");
            }
            Console.WriteLine($"+{line}+");
        }
        Console.WriteLine();
    }

    async Task DisplayData()
    {
        dataList = await _mediator.Send(new GetDataListQuery());
        const int cellWidth = -20;
        string line = new('-', 83);
        Console.WriteLine($"+{line}+");
        Console.WriteLine($"|{"DATA",-83}|");
        Console.WriteLine($"+{line}+");
        if (dataList.Count > 0)
        {
            Console.WriteLine($"|{"Id",cellWidth}|{"Placeholder",cellWidth}|{"Value",cellWidth}|{"Type",cellWidth}|");
            Console.WriteLine($"+{line}+");
            foreach (Data data in dataList)
            {
                Console.WriteLine($"|{data.Id,cellWidth}|{data.Placeholder,cellWidth}|{data.Value,cellWidth}|{data.Type,cellWidth}|");
            }
            Console.WriteLine($"+{line}+");
        }
        Console.WriteLine();
    }

    static void DisplayDocument(Document document)
    {
        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");
        Console.WriteLine(document.Name);
        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");
        Console.WriteLine(document.Content);
        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");
    }

    /*static void DisplayClassDiagram()
    {
        Type[] typelist = GetTypesInNamespace(typeof(Data).GetTypeInfo().Assembly, "ElectroformLite.Domain.Models");
        Console.WriteLine(Mermaid.GenerateClassDiagram(typelist));
    }

    static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
    {
        return assembly.GetTypes()
            .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
            .ToArray();
    }*/
}
