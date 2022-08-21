using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.InMemory;

public class InMemoryDataGroupTemplateRepository : IDataGroupTemplateRepository
{
    readonly List<DataGroupTemplate> dataGroupTemplates = new();

    public void Create(DataGroupTemplate dataGroupTemplate)
    {
        dataGroupTemplate.Id = Guid.NewGuid();
        dataGroupTemplates.Add(dataGroupTemplate);
    }

    public void Delete(Guid id)
    {
        DataGroupTemplate dataGroupTemplate = dataGroupTemplates.FirstOrDefault(d => d.Id == id);
        dataGroupTemplates.Remove(dataGroupTemplate);
    }

    public DataGroupTemplate GetDataGroupTemplate(Guid id)
    {
        return dataGroupTemplates.FirstOrDefault(d => d.Id == id);
    }

    public List<DataGroupTemplate> GetDataGroupTemplates()
    {
        return dataGroupTemplates;
    }

    public void Update(DataGroupTemplate dataGroupTemplate)
    {
        DataGroupTemplate? dataGroupTemplateToEdit = dataGroupTemplates.FirstOrDefault(d => d.Id == dataGroupTemplate.Id);
        if (dataGroupTemplateToEdit is not null)
        {
            dataGroupTemplateToEdit.Name = dataGroupTemplate.Name;
            //dataGroupTemplateToEdit.Type = dataGroupTemplate.Type;
            //dataGroupTemplateToEdit.DataTemplates = dataGroupTemplate.DataTemplates;
        }
    }
}
