using ElectroformLite.Domain.Models;
using ElectroformLite.Domain.Services;
using System.Text.RegularExpressions;

List<Data> dataList = DataService.GetData();
List<DataGroup> dataGroups = DataGroupService.GetDataGroups();

List<Template> templates = TemplateService.GetTemplates();
List<Document> documents = DocumentService.GetDocuments();

List<int> dataGroupIndices = new() { 0, 1 };
List<int> documentIndices = new();

//User user = UserService.GetUser("John Doh", dataGroupIndices, documentIndices);

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

            string templatePlaceholder = $"[{dataGroup.Type}.{data.Placeholder}]";

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
    return dataGroups.First(g => g.Type == dataType);
}