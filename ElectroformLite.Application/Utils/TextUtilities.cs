namespace ElectroformLite.Application.Utils;

public static class TextUtilities
{
    public static string ReplacePlaceholders(string value, Dictionary<string, string> dataDictionary)
    {
        string output = value;
        foreach (KeyValuePair<string, string> dataKeyValuePair in dataDictionary)
        {
            output = output.Replace(dataKeyValuePair.Key, dataKeyValuePair.Value);
        }
        return output;
    }

    public static string GeneratePlaceholder(string aliasName, string dataPlaceholder)
    {
        return $"[{aliasName}.{dataPlaceholder}]";
    }
}
