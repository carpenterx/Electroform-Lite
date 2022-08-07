using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.InMemory;

public class InMemoryDataGroupTemplateRepository : IDataGroupTemplateRepository
{
    readonly List<DataGroupTemplate> dataGroupTemplates = new();

    public void Create(DataGroupTemplate dataGroupTemplate)
    {
        int previousId;
        if (dataGroupTemplates.Count > 0)
        {
            previousId = dataGroupTemplates[^1].Id;
        }
        else
        {
            previousId = -1;
        }
        dataGroupTemplate.Id = previousId + 1;
        dataGroupTemplates.Add(dataGroupTemplate);
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public DataGroupTemplate GetDataGroupTemplate(int id)
    {
        return dataGroupTemplates.FirstOrDefault(d => d.Id == id);
    }

    public List<DataGroupTemplate> GetDataGroupTemplates()
    {
        /*DataGroupTemplate personDataGroupTemplate = new() { Id = 0, Name = "Person", Type = 0 };
        personDataGroupTemplate.DataTemplates.Add(0);
        personDataGroupTemplate.DataTemplates.Add(1);
        dataGroupTemplates.Add(personDataGroupTemplate);

        DataGroupTemplate contactDataGroupTemplate = new() { Id = 1, Name = "Contact", Type = 1 };
        contactDataGroupTemplate.DataTemplates.Add(2);
        contactDataGroupTemplate.DataTemplates.Add(3);
        dataGroupTemplates.Add(contactDataGroupTemplate);*/

        return dataGroupTemplates;
    }

    public void Update(DataGroupTemplate dataGroupTemplate)
    {
        throw new NotImplementedException();
    }
}
