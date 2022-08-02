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
            default:
                DisplayCommandsHint();
                break;
        }
    } while (consoleKeyInfo.Key != ConsoleKey.Escape);
}

void DisplayCommandsHint()
{
    Console.WriteLine("+-----------------------+");
    Console.WriteLine("|Commands:              |");
    Console.WriteLine("|(1) Create data groups |");
    Console.WriteLine("|(2) Create document    |");
    Console.WriteLine("|(Esc) to quit          |");
    Console.WriteLine("+-----------------------+");
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