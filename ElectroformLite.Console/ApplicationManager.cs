using ElectroformLite.Application.DataGroups.Commands.CreateDataGroup;
using ElectroformLite.Application.DataGroups.Queries.GetDataGroup;
using ElectroformLite.Application.DataGroups.Queries.GetDataGroupsByType;
using ElectroformLite.Application.DataGroups.Queries.GetDataGroups;
using ElectroformLite.Application.DataGroupTemplates.Commands.CreateDataGroupTemplate;
using ElectroformLite.Application.DataGroupTemplates.Queries.GetDataGroupTemplate;
using ElectroformLite.Application.DataGroupTemplates.Queries.GetDataGroupTemplates;
using ElectroformLite.Application.DataGroupTypes.Commands.CreateDataGroupType;
using ElectroformLite.Application.DataGroupTypes.Queries.GetDataGroupType;
using ElectroformLite.Application.DataGroupTypes.Queries.GetDataGroupTypes;
using ElectroformLite.Application.DataTemplates.Commands.CreateDataTemplate;
using ElectroformLite.Application.DataTemplates.Queries.GetDataTemplate;
using ElectroformLite.Application.DataTemplates.Queries.GetDataTemplates;
using ElectroformLite.Application.DataTypes.Commands.CreateDataType;
using ElectroformLite.Application.DataTypes.Queries.GetDataTypes;
using ElectroformLite.Application.Documents.Commands.CreateDocument;
using ElectroformLite.Application.Documents.Commands.DeleteDocument;
using ElectroformLite.Application.Documents.Commands.EditDocument;
using ElectroformLite.Application.Documents.Queries.GetDocument;
using ElectroformLite.Application.Documents.Queries.GetDocuments;
using ElectroformLite.Application.Templates.Commands.CreateTemplate;
using ElectroformLite.Application.Templates.Queries.FindTemplates;
using ElectroformLite.Application.Templates.Queries.GetTemplates;
using ElectroformLite.Application.UserData.Commands.CreateData;
using ElectroformLite.Application.UserData.Queries.GetData;
using ElectroformLite.Application.UserData.Queries.GetDataList;
using ElectroformLite.Application.Users.Queries.GetUser;
using ElectroformLite.ClassDiagram;
using ElectroformLite.Domain.Models;
using MediatR;
using System.Reflection;
using System.Text.Json;
using ElectroformLite.Application.Templates.Queries.GetTemplate;
using ElectroformLite.Application.DataGroups.Commands.EditDataGroup;
using ElectroformLite.Application.DataGroups.Commands.DeleteDataGroup;
using ElectroformLite.Application.Users.Commands.CreateUser;
using ElectroformLite.Application.Users.Queries.GetUsers;

namespace ElectroformLite.ConsolePresentation;

public class ApplicationManager
{
    readonly IMediator _mediator;

    public ApplicationManager(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async void StartApplication()
    {
        await PopulateTemplates();

        await DisplayCommandsMenu();
    }

    async Task PopulateTemplates()
    {
        User regularUser = new("User", "user");
        int regularUserId = await _mediator.Send(new CreateUserCommand(regularUser));
        User adminUser = new("Admin", "admin", true);
        int adminUserId = await _mediator.Send(new CreateUserCommand(adminUser));

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

        string templateName = "Cerere plata online for [Person.FirstName] [Person.LastName]";
        string templateContent = @"Cerere Alocare Credentiale Pentru Plata Impozitelor Si Taxelor Locale Pentru Persoane Fizice

Subsemnatul/a [Person.FirstName] [Person.LastName], e-mail [Contact.Email], numar de
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

        int cerereTemplateId = await _mediator.Send(new CreateTemplateCommand(templateName, templateContent, dataGroupTemplates));
    }

    async Task FindTemplate()
    {
        Console.WriteLine("Find template:");
        string searchTerm = Console.ReadLine();
        List<Template> foundTemplates = await _mediator.Send(new FindTemplatesQuery(searchTerm));
        if (foundTemplates.Count > 0)
        {
            Console.WriteLine($"Using template: {foundTemplates[0].Name}");
            await GenerateDocument(foundTemplates[0].Id);
        }
    }

    async Task GenerateDocument(int templateId)
    {
        // get template
        Template template = await _mediator.Send(new GetTemplateQuery(templateId));
        string documentTitle = template.Name;
        string documentContent = template.Content;

        List<int> dataGroupIds = new();
        // get each data group template
        foreach (int dataGroupTemplateId in template.DataGroupTemplates)
        {
            DataGroupTemplate dataGroupTemplate = await _mediator.Send(new GetDataGroupTemplateQuery(dataGroupTemplateId));
            DataGroupType dataGroupType = await _mediator.Send(new GetDataGroupTypeQuery(dataGroupTemplate.Type));
            List<DataGroup> sameTypeDataGroups = await _mediator.Send(new GetDataGroupsByTypeQuery(dataGroupTemplate.Type));
            int chosenDataGroupId = ChooseDataGroupId(sameTypeDataGroups);
            if (chosenDataGroupId != -1)
            {
                DataGroup dataGroup = await _mediator.Send(new GetDataGroupQuery(chosenDataGroupId));
                foreach (int dataId in dataGroup.Data)
                {
                    Data data = await _mediator.Send(new GetDataQuery(dataId));
                    documentTitle = documentTitle.Replace($"[{dataGroupType.Value}.{data.Placeholder}]", data.Value);
                    documentContent = documentContent.Replace($"[{dataGroupType.Value}.{data.Placeholder}]", data.Value);
                }
            }
            else
            {
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
                    documentTitle = documentTitle.Replace($"[{dataGroupType.Value}.{data.Placeholder}]", data.Value);
                    documentContent = documentContent.Replace($"[{dataGroupType.Value}.{data.Placeholder}]", data.Value);
                }
                // generate each data group
                DataGroup dataGroup = new(dataGroupTemplate, dataGroupName, dataIds);
                int dataGroupId = await _mediator.Send(new CreateDataGroupCommand(dataGroup));
                dataGroupIds.Add(dataGroupId);
            }
        }
        // generate document
        Console.WriteLine($"Document name: {documentTitle}");
        string documentName = Console.ReadLine();
        Document document = new(documentName, documentContent, templateId, dataGroupIds);
        await _mediator.Send(new CreateDocumentCommand(document));
        DisplayDocument(document);
    }

    static int ChooseDataGroupId(List<DataGroup> sameTypeDataGroups)
    {
        if (sameTypeDataGroups.Count == 0)
        {
            return -1;
        }
        else
        {
            return ShowChoiceMenu(sameTypeDataGroups);
        }
    }

    static int ShowChoiceMenu(List<DataGroup> sameTypeDataGroups)
    {
        int chosenId;
        const int menuWidth = 80;
        string line = new('-', menuWidth);
        int[] ids = { -1, -1, -1, -1, -1, -1 };

        Console.WriteLine($"+{line}+");
        Console.WriteLine($"|{"Choose an option:",-menuWidth}|");
        Console.WriteLine($"+{line}+");
        int size = Math.Min(sameTypeDataGroups.Count, ids.Length);
        for (int i = 0; i < size; i++)
        {
            ids[i] = sameTypeDataGroups[i].Id;
            string dataGroupText = $"({i}) DataGroup with id {sameTypeDataGroups[i].Id}: {sameTypeDataGroups[i].Name}";
            Console.WriteLine($"|{dataGroupText,-menuWidth}|");
        }
        Console.WriteLine($"|{"(Other) Create new",-menuWidth}|");
        Console.WriteLine($"+{line}+");
        ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
        switch (consoleKeyInfo.Key)
        {
            case ConsoleKey.D0:
                chosenId = ids[0];
                break;
            case ConsoleKey.D1:
                chosenId = ids[1];
                break;
            case ConsoleKey.D2:
                chosenId = ids[2];
                break;
            case ConsoleKey.D3:
                chosenId = ids[3];
                break;
            case ConsoleKey.D4:
                chosenId = ids[4];
                break;
            case ConsoleKey.D5:
                chosenId = ids[5];
                break;
            default:
                chosenId = -1;
                break;
        }
        return chosenId;
    }

    async Task DisplayCommandsMenu()
    {
        DisplayCommandsHint();

        ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);

        Console.Clear();
        switch (consoleKeyInfo.Key)
        {
            case ConsoleKey.D1:
                await ManageDocuments();
                break;
            case ConsoleKey.D2:
                await ManageDataGroups();
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
        Console.WriteLine($"|{"(1) Manage Documents",-menuWidth}|");
        Console.WriteLine($"|{"(2) Manage Data Groups",-menuWidth}|");
        Console.WriteLine($"|{"(3) Display User Data",-menuWidth}|");
        Console.WriteLine($"|{"(4) Display Template Data",-menuWidth}|");
        Console.WriteLine($"+{line}+");
    }

    async Task ManageDocuments()
    {
        DisplayDocumentManagementOptions();

        ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);

        Console.Clear();
        switch (consoleKeyInfo.Key)
        {
            case ConsoleKey.D1:
                await CreateDocument();
                break;
            case ConsoleKey.D2:
                await EditDocument();
                break;
            case ConsoleKey.D3:
                await DeleteDocument();
                break;
            case ConsoleKey.D4:
                await ExportDocument();
                break;
            case ConsoleKey.D5:
                await LoadDocument();
                break;
            default:
                await DisplayCommandsMenu();
                break;
        }
    }

    static void DisplayDocumentManagementOptions()
    {
        const int menuWidth = 40;
        string line = new('-', menuWidth);

        Console.WriteLine($"+{line}+");
        Console.WriteLine($"|{"Manage documents:",-menuWidth}|");
        Console.WriteLine($"+{line}+");
        Console.WriteLine($"|{"(1) Create document",-menuWidth}|");
        Console.WriteLine($"|{"(2) Edit document",-menuWidth}|");
        Console.WriteLine($"|{"(3) Delete document",-menuWidth}|");
        Console.WriteLine($"|{"(4) Export document",-menuWidth}|");
        Console.WriteLine($"|{"(5) Load document",-menuWidth}|");
        Console.WriteLine($"+{line}+");
    }

    async Task ExportDocument()
    {
        Document document = await _mediator.Send(new GetDocumentQuery(0));
        var newFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "output.json");

        var fileStream = File.Create(newFilePath);

        using (StreamWriter sw = new(fileStream))
        {
            JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };
            string json = JsonSerializer.Serialize(document, jsonSerializerOptions);
            sw.Write(json);
        }
        await DisplayCommandsMenu();
    }

    async Task LoadDocument()
    {
        var newFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "output.json");
        using var sr = new StreamReader(newFilePath);
        string documentJson = sr.ReadToEnd();
        sr.Close();
        Console.WriteLine(documentJson);
        try
        {
            Document? document = JsonSerializer.Deserialize<Document>(documentJson);
            if (document is not null)
            {
                await _mediator.Send(new CreateDocumentCommand(document));
                await DisplayDocuments();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        await DisplayCommandsMenu();
    }

    async Task DeleteDocument()
    {
        await _mediator.Send(new DeleteDocumentCommand(0));
        await DisplayCommandsMenu();
    }

    async Task EditDocument()
    {
        Document document = await _mediator.Send(new GetDocumentQuery(0));
        Console.WriteLine("New document name:");
        document.Name = Console.ReadLine();
        await _mediator.Send(new EditDocumentCommand(document));
        await DisplayCommandsMenu();
    }

    async Task CreateDocument()
    {
        await FindTemplate();
        //await GenerateDocument(cerereTemplateId);

        await DisplayData();
        await DisplayDataGroups();
        await DisplayDocuments();
        await DisplayCommandsMenu();
    }

    async Task ManageDataGroups()
    {
        DisplayDataGroupManagementOptions();

        ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);

        Console.Clear();
        switch (consoleKeyInfo.Key)
        {
            case ConsoleKey.D1:
                await CreateDataGroup();
                break;
            case ConsoleKey.D2:
                await EditDataGroup();
                break;
            case ConsoleKey.D3:
                await DeleteDataGroup();
                break;
            default:
                await DisplayCommandsMenu();
                break;
        }
    }

    async Task CreateDataGroup()
    {
        DataGroupTemplate dataGroupTemplate = await _mediator.Send(new GetDataGroupTemplateQuery(0));
        Console.WriteLine("Data group name:");
        string dataGroupName = Console.ReadLine();
        DataGroup dataGroup = new(dataGroupTemplate, dataGroupName, new());
        await _mediator.Send(new CreateDataGroupCommand(dataGroup));
        await DisplayCommandsMenu();
    }

    async Task EditDataGroup()
    {
        DataGroup dataGroup = await _mediator.Send(new GetDataGroupQuery(0));
        Console.WriteLine("New data group name:");
        dataGroup.Name = Console.ReadLine();
        await _mediator.Send(new EditDataGroupCommand(dataGroup));
        await DisplayCommandsMenu();
    }

    async Task DeleteDataGroup()
    {
        await _mediator.Send(new DeleteDataGroupCommand(0));
        await DisplayCommandsMenu();
    }

    static void DisplayDataGroupManagementOptions()
    {
        const int menuWidth = 40;
        string line = new('-', menuWidth);

        Console.WriteLine($"+{line}+");
        Console.WriteLine($"|{"Manage data groups:",-menuWidth}|");
        Console.WriteLine($"+{line}+");
        Console.WriteLine($"|{"(1) Create data group",-menuWidth}|");
        Console.WriteLine($"|{"(2) Edit data group",-menuWidth}|");
        Console.WriteLine($"|{"(3) Delete data group",-menuWidth}|");
        Console.WriteLine($"+{line}+");
    }

    async Task DisplayUserData()
    {
        await DisplayUsers();
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
        List<Template> templates = await _mediator.Send(new GetTemplatesQuery());
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
        List<DataGroupTemplate> dataGroupTemplates = await _mediator.Send(new GetDataGroupTemplatesQuery());
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
        List<DataGroupType> dataGroupTypes = await _mediator.Send(new GetDataGroupTypesQuery());
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
        List<DataTemplate> dataTemplates = await _mediator.Send(new GetDataTemplatesQuery());
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
        List<DataType> dataTypes = await _mediator.Send(new GetDataTypesQuery());
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

    async Task DisplayUsers()
    {
        List<User> users = await _mediator.Send(new GetUsersQuery());
        const int cellWidth = -20;
        string line = new('-', 83);
        Console.WriteLine($"+{line}+");
        Console.WriteLine($"|{"Users",-83}|");
        Console.WriteLine($"+{line}+");
        if (users.Count > 0)
        {
            Console.WriteLine($"|{"Id",cellWidth}|{"Name",cellWidth}|{"Password",cellWidth}|{"IsAdmin",cellWidth}|");
            Console.WriteLine($"+{line}+");
            foreach (User user in users)
            {
                Console.WriteLine($"|{user.Id,cellWidth}|{user.Name,cellWidth}|{user.Password,cellWidth}|{user.IsAdmin,cellWidth}|");
            }
            Console.WriteLine($"+{line}+");
        }
        Console.WriteLine();
    }

    async Task DisplayDocuments()
    {
        List<Document> documents = await _mediator.Send(new GetDocumentsQuery());
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
        List<DataGroup> dataGroups = await _mediator.Send(new GetDataGroupsQuery());
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
        List<Data> dataList = await _mediator.Send(new GetDataListQuery());
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
