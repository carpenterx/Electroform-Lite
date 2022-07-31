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
List<Document> documents = DocumentService.GetDocuments();

List<int> dataGroupIndices = new() { 0, 1 };
List<int> documentIndices = new();

//User user = UserService.GetUser("John Doh", dataGroupIndices, documentIndices);

DataGroup personDataGroup = CreateBasicDataGroup(0, "John Doh");
FillDataGroup(personDataGroup);
dataGroups.Add(personDataGroup);

DataGroup contactDataGroup = CreateBasicDataGroup(1, "John Doh Contact");
FillDataGroup(contactDataGroup);
dataGroups.Add(contactDataGroup);

Console.WriteLine("Select template id:");
try
{
    int templateId = int.Parse(Console.ReadLine());
    Document document = CreateBasicDocument(templateId);
    Console.WriteLine(document.Name);
    Console.WriteLine(document.Content);
}
catch (Exception)
{
    
}

/*Type[] typelist = GetTypesInNamespace(typeof(Data).GetTypeInfo().Assembly, "ElectroformLite.Domain.Models");
Console.WriteLine(Mermaid.GenerateClassDiagram(typelist));

Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
{
    return assembly.GetTypes()
        .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
        .ToArray();
}*/

DataGroup CreateBasicDataGroup(int dataGroupTemplateId, string name)
{
    DataGroup dataGroup = new DataGroup(dataGroupTemplates[dataGroupTemplateId], name);

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
    Console.WriteLine($"Data group: {dataGroup.Name}");
    foreach (int dataIndex in dataGroup.Data)
    {
        Data data = dataList[dataIndex];
        Console.WriteLine($"{data.Placeholder}: ");
        data.Value = Console.ReadLine();
    }
}

Document CreateBasicDocument(int templateId)
{
    Template template = templates[templateId];

    string output = template.Content;

    List<string> dataGroupTypes = GetDataGroupTypesFromTemplate(template.Content);

    List<int> usedDataGroupIds = new();

    foreach (string dataGroupType in dataGroupTypes)
    {
        DataGroup dataGroup = GetDataGroupByType(dataGroupType);
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

DataGroup GetDataGroupByType(string dataType)
{
    int dataTypeId = dataGroupTypes.First(t => t.Value == dataType).Id;
    return dataGroups.First(g => g.Type == dataTypeId);
}