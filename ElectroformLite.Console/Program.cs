using ElectroformLite.ClassDiagram;
using ElectroformLite.Domain.Models;
using ElectroformLite.Domain.Services;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

List<DataType> dataTypes = DataTypeService.GetDataTypes();
List<DataTemplate> dataTemplates = DataTemplateService.GetDataTemplates();
//List<Data> dataList = DataService.GetData();
List<Data> dataList = new();

List<DataGroupType> dataGroupTypes = DataGroupTypeService.GetDataGroupTypes();
List<DataGroupTemplate> dataGroupTemplates = DataGroupTemplateService.GetDataGroupTemplates();
//List<DataGroup> dataGroups = DataGroupService.GetDataGroups();
List<DataGroup> dataGroups = new();

List<Template> templates = TemplateService.GetTemplates();
//List<Document> documents = DocumentService.GetDocuments();
List<Document> documents = new();

/*List<int> dataGroupIndices = new() { 0, 1 };
List<int> documentIndices = new();
User user = UserService.GetUser("John Doh", dataGroupIndices, documentIndices);*/

DisplayCommandsMenu();

/*Type[] typelist = GetTypesInNamespace(typeof(Data).GetTypeInfo().Assembly, "ElectroformLite.Domain.Models");
Console.WriteLine(Mermaid.GenerateClassDiagram(typelist));

Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
{
    return assembly.GetTypes()
        .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
        .ToArray();
}*/

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
        Data data = new(dataTemplates[dataTemplateId]);
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