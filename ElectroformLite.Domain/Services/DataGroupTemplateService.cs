using ElectroformLite.Domain.Models;

namespace ElectroformLite.Domain.Services;

public class DataGroupTemplateService
{
    public static List<DataGroupTemplate> GetDataGroupTemplates()
    {
        List<DataGroupTemplate> dataGroupTemplates = new();

        DataGroupTemplate personDataGroupTemplate = new() { Id = 0, Type = 0 };
        personDataGroupTemplate.DataTemplates.Add(0);
        personDataGroupTemplate.DataTemplates.Add(1);
        dataGroupTemplates.Add(personDataGroupTemplate);

        DataGroupTemplate contactDataGroupTemplate = new() { Id = 1, Type = 1 };
        contactDataGroupTemplate.DataTemplates.Add(0);
        contactDataGroupTemplate.DataTemplates.Add(1);
        dataGroupTemplates.Add(contactDataGroupTemplate);

        return dataGroupTemplates;
    }
}
