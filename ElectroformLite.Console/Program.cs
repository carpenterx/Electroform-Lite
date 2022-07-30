using ElectroformLite.Domain.Models;
using ElectroformLite.Domain.Services;
using System.Text;
using System.Text.RegularExpressions;

List<Data> dataList = DataService.GetData();
List<DataGroup> dataGroups = DataGroupService.GetDataGroups();

List<Template> templates = TemplateService.GetTemplates();
List<Document> documents = DocumentService.GetDocuments();

List<int> dataGroupIndices = new() { 0, 1 };
List<int> documentIndices = new();

//User user = UserService.GetUser("John Doh", dataGroupIndices, documentIndices);

/*Console.WriteLine("Select template id:");
try
{
    int templateId = int.Parse(Console.ReadLine());
    Document document = CreateBasicDocument(templateId);
    Console.WriteLine(document.Name);
    Console.WriteLine(document.Content);
}
catch (Exception)
{
    
}*/

Console.WriteLine(GenerateClassDiagram()); ;

string GenerateClassDiagram()
{
    StringBuilder classDiagramStringBuilder = new();
    //classDiagramStringBuilder.AppendLine("```mermaid");
    classDiagramStringBuilder.Append(ExtractMethods(typeof(User)));
    classDiagramStringBuilder.Append(ExtractMethods(typeof(Data)));
    classDiagramStringBuilder.Append(ExtractMethods(typeof(DataGroup)));
    classDiagramStringBuilder.Append(ExtractMethods(typeof(Document)));
    classDiagramStringBuilder.Append(ExtractMethods(typeof(Template)));
    //classDiagramStringBuilder.AppendLine("```");
    return classDiagramStringBuilder.ToString();
}

StringBuilder ExtractMethods(Type type)
{
    List<string> props = new();
    List<string> methods = new();
    foreach (var method in type.GetMethods())
    {
        var parameters = method.GetParameters();
        var parameterDescriptions = string.Join(", ", method.GetParameters()
            .Select(x => x.ParameterType.Name + " " + x.Name)
            .ToArray());
        
        if (type.FullName == method.DeclaringType.FullName)
        {
            string methodName = method.Name;
            if (methodName.StartsWith("get_"))
            {
                //props.Add($"{method.ReturnType.Name} {methodName.Replace("get_", "")}");
                props.Add($"{methodName.Replace("get_", "")}");
            }
            else if (methodName.StartsWith("set_"))
            {
                //Console.WriteLine($"{method.ReturnType.Name} {methodName.Replace("get_", "")}");
            }
            else
            {
                //methods.Add($"{method.ReturnType.Name} {methodName}({parameterDescriptions})");
                methods.Add($"{methodName}({parameterDescriptions})");
            }
        }
    }

    return GenerateClassCode(type.Name, props, methods);
}

StringBuilder GenerateClassCode(string name, List<string> props, List<string> methods)
{
    StringBuilder stringBuilder = new();
    stringBuilder.AppendLine($"class {name}{{");
    foreach (string prop in props)
    {
        stringBuilder.AppendLine(prop);
    }
    if (methods.Count > 0)
    {
        stringBuilder.AppendLine();
    }
    foreach (string method in methods)
    {
        stringBuilder.AppendLine(method);
    }
    stringBuilder.AppendLine("}");

    return stringBuilder;
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