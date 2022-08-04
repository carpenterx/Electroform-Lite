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

    public Data GetDataTemplate(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(DataTemplate dataTemplate)
    {
        throw new NotImplementedException();
    }

    public List<DataTemplate> GetDataTemplates()
    {
        /*DataTemplate firstName = new() { Id = 0, Placeholder = "FirstName", Type = 0 };
        DataTemplate lastName = new() { Id = 1, Placeholder = "LastName", Type = 0 };
        DataTemplate email = new() { Id = 2, Placeholder = "Email", Type = 2 };
        DataTemplate phone = new() { Id = 3, Placeholder = "PhoneNumber", Type = 1 };

        dataTemplates.Add(firstName);
        dataTemplates.Add(lastName);
        dataTemplates.Add(email);
        dataTemplates.Add(phone);*/

        return dataTemplates;
    }
}
