using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.InMemory;

public class InMemoryDataGroupTemplateRepository : IDataGroupTemplateRepository
{
    public List<DataGroupTemplate> GetDataGroupTemplates()
    {
        List<DataGroupTemplate> dataGroupTemplates = new();

        DataGroupTemplate personDataGroupTemplate = new() { Id = 0, Name = "Person", Type = 0 };
        personDataGroupTemplate.DataTemplates.Add(0);
        personDataGroupTemplate.DataTemplates.Add(1);
        dataGroupTemplates.Add(personDataGroupTemplate);

        DataGroupTemplate contactDataGroupTemplate = new() { Id = 1, Name = "Contact", Type = 1 };
        contactDataGroupTemplate.DataTemplates.Add(2);
        contactDataGroupTemplate.DataTemplates.Add(3);
        dataGroupTemplates.Add(contactDataGroupTemplate);

        return dataGroupTemplates;
    }
}
