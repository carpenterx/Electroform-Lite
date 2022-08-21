using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.InMemory;

public class InMemoryDataTemplateRepository : IDataTemplateRepository
{
    readonly List<DataTemplate> dataTemplates = new();

    public void Create(DataTemplate dataTemplate)
    {
        dataTemplate.Id = Guid.NewGuid();
        dataTemplates.Add(dataTemplate);
    }

    public void Delete(Guid id)
    {
        DataTemplate dataTemplate = dataTemplates.FirstOrDefault(d => d.Id == id);
        dataTemplates.Remove(dataTemplate);
    }

    public DataTemplate GetDataTemplate(Guid id)
    {
        return dataTemplates.FirstOrDefault(d => d.Id == id);
    }

    public void Update(DataTemplate dataTemplate)
    {
        DataTemplate? dataTemplateToUpdate = dataTemplates.FirstOrDefault(d => d.Id == dataTemplate.Id);
        if (dataTemplateToUpdate is null)
        {
            throw new InvalidOperationException($"Data template with id {dataTemplate.Id} not found");
        }
        dataTemplateToUpdate.Placeholder = dataTemplate.Placeholder;
        //dataTemplateToUpdate.Type = dataTemplate.Type;
    }

    public List<DataTemplate> GetDataTemplates()
    {
        return dataTemplates;
    }
}
