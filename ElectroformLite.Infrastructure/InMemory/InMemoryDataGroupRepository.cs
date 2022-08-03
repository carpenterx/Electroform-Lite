using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.InMemory;

public class InMemoryDataGroupRepository : IDataGroupRepository
{
    public List<DataGroup> GetDataGroups()
    {
        List<DataGroup> dataGroups = new();
        DataGroup personDataGroup = new()
        {
            Id = 0,
            Name = "John Doh",
            Type = 0
        };
        personDataGroup.Data.Add(0);
        personDataGroup.Data.Add(1);
        dataGroups.Add(personDataGroup);

        DataGroup contactDataGroup = new()
        {
            Id = 1,
            Name = "John Doh Contact",
            Type = 1
        };
        contactDataGroup.Data.Add(2);
        contactDataGroup.Data.Add(3);
        dataGroups.Add(contactDataGroup);

        return dataGroups;
    }
}
