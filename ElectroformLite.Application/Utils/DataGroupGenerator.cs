using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Utils;

public static class DataGroupGenerator
{
    public static DataGroup GenerateDataGroup(DataGroupTemplate dataGroupTemplate, string[] values)
    {
        int maxIndex = Math.Min(dataGroupTemplate.DataGroups.Count, values.Length);
        for (int i = 0; i < maxIndex; i++)
        {
            Data data = new() { Value = values[i] };
        }

        return null;
    }
}
