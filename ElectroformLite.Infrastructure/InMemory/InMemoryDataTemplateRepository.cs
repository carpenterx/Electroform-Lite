using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.InMemory;

public class InMemoryDataTemplateRepository : IDataTemplateRepository
{
    public List<DataTemplate> GetDataTemplates()
    {
        List<DataTemplate> dataTemplates = new();

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
