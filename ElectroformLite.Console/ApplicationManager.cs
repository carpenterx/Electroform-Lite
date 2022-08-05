using ElectroformLite.Application.DataGroups.Queries.GetDataGroupsList;
using ElectroformLite.Application.DataGroupTemplates.Commands.CreateDataGroupTemplate;
using ElectroformLite.Application.DataGroupTemplates.Queries.GetDataGroupTemplatesList;
using ElectroformLite.Application.DataGroupTypes.Commands.CreateDataGroupType;
using ElectroformLite.Application.DataGroupTypes.Queries.GetDataGroupTypesList;
using ElectroformLite.Application.DataTemplates.Commands.CreateDataTemplate;
using ElectroformLite.Application.DataTemplates.Queries.GetDataTemplatesList;
using ElectroformLite.Application.DataTypes.Commands.CreateDataType;
using ElectroformLite.Application.DataTypes.Queries.GetDataTypesList;
using ElectroformLite.Application.Documents.Queries.GetDocuments;
using ElectroformLite.Application.Templates.Commands.CreateTemplateCommand;
using ElectroformLite.Application.Templates.Queries.GetTemplates;
using ElectroformLite.Application.UserData.Commands.CreateData;
using ElectroformLite.Application.UserData.Queries.GetDataList;
using ElectroformLite.Application.Users.Queries.GetUser;
using ElectroformLite.Domain.Models;
using MediatR;
using System.Text.RegularExpressions;

namespace ElectroformLite.ConsolePresentation;

public class ApplicationManager
{
    //List<DataType> dataTypes = DataTypeService.GetDataTypes();
    List<DataType> dataTypes = new();
    //List<DataTemplate> dataTemplates = DataTemplateService.GetDataTemplates();
    List<DataTemplate> dataTemplates = new();
    //List<Data> dataList = DataService.GetData();
    //List<Data> dataList = new();
    List<Data> dataList = new();

    //List<DataGroupType> dataGroupTypes = DataGroupTypeService.GetDataGroupTypes();
    List<DataGroupType> dataGroupTypes = new();
    //List<DataGroupTemplate> dataGroupTemplates = DataGroupTemplateService.GetDataGroupTemplates();
    List<DataGroupTemplate> dataGroupTemplates = new();
    //List<DataGroup> dataGroups = DataGroupService.GetDataGroups();
    List<DataGroup> dataGroups = new();

    //List<Template> templates = TemplateService.GetTemplates();
    List<Template> templates = new();
    //List<Document> documents = DocumentService.GetDocuments();
    List<Document> documents = new();

    /*List<int> dataGroupIndices = new() { 0, 1 };
    List<int> documentIndices = new();
    User user = UserService.GetUser("John Doh", dataGroupIndices, documentIndices);*/
    User user = new();

    //DisplayCommandsMenu();

    /*Type[] typelist = GetTypesInNamespace(typeof(Data).GetTypeInfo().Assembly, "ElectroformLite.Domain.Models");
    Console.WriteLine(Mermaid.GenerateClassDiagram(typelist));

    Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
    {
        return assembly.GetTypes()
            .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
            .ToArray();
    }*/

    readonly IMediator _mediator;

    public ApplicationManager(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async void StartApplication()
    {
        /*user = await _mediator.Send(new GetUserQuery(0));

        dataList = await _mediator.Send(new GetDataListQuery());
        //DisplayData();
        dataTypes = await _mediator.Send(new GetDataTypesListQuery());
        //DisplayDataTypes();
        dataGroups = await _mediator.Send(new GetDataGroupsListQuery());
        //DisplayDataGroups();
        dataGroupTemplates = await _mediator.Send(new GetDataGroupTemplatesListQuery());
        //DisplayDataGroupTemplates();
        dataGroupTypes = await _mediator.Send(new GetDataGroupTypesListQuery());
        //DisplayDataGroupTypes();
        dataTemplates = await _mediator.Send(new GetDataTemplatesListQuery());
        //DisplayDataTemplates();
        documents = await _mediator.Send(new GetDocumentsQuery());
        //DisplayDocuments();
        templates = await _mediator.Send(new GetTemplatesQuery());
        //DisplayTemplates();*/

        /*await PopulateDataTemplates();
        dataTemplates = await _mediator.Send(new GetDataTemplatesListQuery());
        DisplayDataTemplates();*/
        /*await PopulateData();
        dataList = await _mediator.Send(new GetDataListQuery());
        DisplayData();*/

        await PopulateTemplates();
        dataTypes = await _mediator.Send(new GetDataTypesListQuery());
        DisplayDataTypes();
        dataTemplates = await _mediator.Send(new GetDataTemplatesListQuery());
        DisplayDataTemplates();
        dataGroupTypes = await _mediator.Send(new GetDataGroupTypesListQuery());
        DisplayDataGroupTypes();
        dataGroupTemplates = await _mediator.Send(new GetDataGroupTemplatesListQuery());
        DisplayDataGroupTemplates();
        templates = await _mediator.Send(new GetTemplatesQuery());
        DisplayTemplates();

        DisplayCommandsMenu();
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

        await _mediator.Send(new CreateDataGroupTemplateCommand("Person", personTypeId, personDataTemplates));
        await _mediator.Send(new CreateDataGroupTemplateCommand("Contact", contactTypeId, contactDataTemplates));

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

        int cerereTemplateId = await _mediator.Send(new CreateTemplateCommand(templateName, templateContent));
    }

    void DisplayCommandsMenu()
    {
        DisplayCommandsHint();

        ConsoleKeyInfo consoleKeyInfo;

        do
        {
            consoleKeyInfo = Console.ReadKey(true);
            Console.Clear();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.D1:
                    CreateDataGroups();
                    break;
                case ConsoleKey.D2:
                    CreateDocument();
                    break;
                case ConsoleKey.D3:
                    DisplayUserData();
                    break;
                case ConsoleKey.D4:
                    DisplayTemplateData();
                    break;
                default:
                    DisplayCommandsHint();
                    break;
            }
        } while (consoleKeyInfo.Key != ConsoleKey.Escape);
    }

    void DisplayCommandsHint()
    {
        const int menuWidth = 40;
        string line = new('-', menuWidth);

        Console.WriteLine($"+{line}+");
        Console.WriteLine($"|{"Commands:",-menuWidth}|");
        Console.WriteLine($"|{"(1) Create data groups",-menuWidth}|");
        Console.WriteLine($"|{"(2) Create document",-menuWidth}|");
        Console.WriteLine($"|{"(3) Display User Data",-menuWidth}|");
        Console.WriteLine($"|{"(4) Display Template Data",-menuWidth}|");
        Console.WriteLine($"|{"(Esc) to quit",-menuWidth}|");
        Console.WriteLine($"+{line}+");
    }

    void CreateDataGroups()
    {
        Console.WriteLine("Create data groups");
        DataGroup personDataGroup = CreateBasicDataGroup(0);
        FillDataGroup(personDataGroup);

        DataGroup contactDataGroup = CreateBasicDataGroup(1);
        FillDataGroup(contactDataGroup);
        DisplayCommandsHint();
    }

    void CreateDocument()
    {
        Console.WriteLine("Create document");
        //Console.WriteLine("Select template id:");
        try
        {
            //int templateId = int.Parse(Console.ReadLine());
            int templateId = 0;
            Document document = CreateBasicDocument(templateId);
            DisplayDocument(document);
            DisplayCommandsHint();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    void DisplayUserData()
    {
        DisplayDocuments();
        DisplayDataGroups();
        DisplayData();
        DisplayCommandsHint();
    }

    void DisplayTemplateData()
    {
        DisplayTemplates();
        DisplayDataGroupTemplates();
        DisplayDataGroupTypes();
        DisplayDataTemplates();
        DisplayDataTypes();
        DisplayCommandsHint();
    }

    void DisplayTemplates()
    {
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

    void DisplayDataGroupTemplates()
    {
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

    void DisplayDataGroupTypes()
    {
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

    void DisplayDataTemplates()
    {
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

    void DisplayDataTypes()
    {
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

    void DisplayDocuments()
    {
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

    void DisplayDataGroups()
    {
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

    void DisplayData()
    {
        const int cellWidth = -20;
        string line = new('-', 83);
        Console.WriteLine($"+{line}+");
        Console.WriteLine($"|{"DATA",-83}|");
        Console.WriteLine($"+{line}+");
        if (dataList.Count() > 0)
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

    void DisplayDocument(Document document)
    {
        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");
        Console.WriteLine(document.Name);
        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");
        Console.WriteLine(document.Content);
        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");
    }

    DataGroup CreateBasicDataGroup(int dataGroupTemplateId)
    {
        DataGroup dataGroup = new(dataGroupTemplates[dataGroupTemplateId], $"{dataGroupTypes[dataGroupTemplates[dataGroupTemplateId].Type].Value} data group");

        int index = dataList.Count;
        foreach (int dataTemplateId in dataGroupTemplates[dataGroupTemplateId].DataTemplates)
        {
            Data data = new(dataTemplates[dataTemplateId], "Bla");
            data.Id = index++;
            dataList.Add(data);
            dataGroup.Data.Add(data.Id);
        }

        return dataGroup;
    }

    void FillDataGroup(DataGroup dataGroup)
    {
        Console.WriteLine($"{dataGroupTypes[dataGroup.Type].Value} data group:");
        foreach (int dataIndex in dataGroup.Data)
        {
            Data data = dataList[dataIndex];
            Console.WriteLine($"{data.Placeholder}: ");
            data.Value = Console.ReadLine();
        }
        dataGroups.Add(dataGroup);
    }

    Document CreateBasicDocument(int templateId)
    {
        Template template = templates[templateId];

        string output = template.Content;

        List<string> dataGroupTypes = GetDataGroupTypesFromTemplate(template.Content);

        List<int> usedDataGroupIds = new();

        foreach (string dataGroupType in dataGroupTypes)
        {
            DataGroup? dataGroup = GetDataGroupByType(dataGroupType);
            if (dataGroup is null)
            {
                dataGroup = CreateBasicDataGroup(GetDataGroupTemplateIdByType(dataGroupType));
                FillDataGroup(dataGroup);
                dataGroups.Add(dataGroup);
            }
            usedDataGroupIds.Add(dataGroup.Id);

            foreach (int dataIndex in dataGroup.Data)
            {
                Data data = dataList[dataIndex];

                string templatePlaceholder = $"[{dataGroupTypes[dataGroup.Type]}.{data.Placeholder}]";

                output = output.Replace(templatePlaceholder, data.Value);
            }
        }

        Document document = new()
        {
            Name = template.Name.Replace("Template for", "Document:"),
            TemplateId = templateId,
            Content = output,
            Created = DateTime.Now,
            DataGroups = new(usedDataGroupIds)
        };

        return document;
    }

    List<string> GetDataGroupTypesFromTemplate(string templateContent)
    {
        MatchCollection matches = Regex.Matches(templateContent, "\\[(.+?)\\.");

        var matchvalues = matches.Select(m => m.Groups[1].Value);

        return matchvalues.Distinct().ToList();
    }

    DataGroup? GetDataGroupByType(string dataGroupType)
    {
        int dataGroupTypeId = dataGroupTypes.First(t => t.Value == dataGroupType).Id;
        return dataGroups.FirstOrDefault(g => g.Type == dataGroupTypeId);
    }

    int GetDataGroupTemplateIdByType(string dataGroupType)
    {
        int dataGroupTypeId = dataGroupTypes.First(t => t.Value == dataGroupType).Id;
        return dataGroupTemplates.First(g => g.Type == dataGroupTypeId).Id;
    }
}
