using System.Text;

namespace ElectroformLite.ClassDiagram;

public static class Mermaid
{
    public static string GenerateClassDiagram(params Type[] classTypes)
    {
        StringBuilder classDiagramStringBuilder = new();
        //classDiagramStringBuilder.AppendLine("```mermaid");
        foreach (Type type in classTypes)
        {
            classDiagramStringBuilder.Append(ExtractMethods(type));
        }
       
        //classDiagramStringBuilder.AppendLine("```");
        return classDiagramStringBuilder.ToString();
    }

    private static StringBuilder ExtractMethods(Type type)
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

    private static StringBuilder GenerateClassCode(string name, List<string> props, List<string> methods)
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
}
