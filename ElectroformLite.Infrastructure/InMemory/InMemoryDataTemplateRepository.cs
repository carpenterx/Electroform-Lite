using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.InMemory;

public class InMemoryDataTemplateRepository : IDataTemplateRepository
{
    readonly List<DataTemplate> dataTemplates = new();

    public void Create(DataTemplate dataTemplate)
    {
        int previousId;
        if (dataTemplates.Count > 0)
        {
            previousId = dataTemplates[^1].Id;
        }
        else
        {
            previousId = -1;
        }
        dataTemplate.Id = previousId + 1;
        dataTemplates.Add(dataTemplate);
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public DataTemplate GetDataTemplate(int id)
    {
        return dataTemplates.FirstOrDefault(d => d.Id == id);
    }

    public void Update(DataTemplate dataTemplate)
    {
        throw new NotImplementedException();
    }

    public List<DataTemplate> GetDataTemplates()
    {
        return dataTemplates;
    }
}
