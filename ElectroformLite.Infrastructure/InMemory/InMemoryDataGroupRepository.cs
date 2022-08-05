using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.InMemory;

public class InMemoryDataGroupRepository : IDataGroupRepository
{
    readonly List<DataGroup> dataGroups = new();

    public void Create(DataGroup dataGroup)
    {
        int previousId;
        if (dataGroups.Count > 0)
        {
            previousId = dataGroups[^1].Id;
        }
        else
        {
            previousId = -1;
        }
        dataGroup.Id = previousId + 1;
        dataGroups.Add(dataGroup);
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public DataGroup GetDataGroup(int id)
    {
        throw new NotImplementedException();
    }

    public List<DataGroup> GetDataGroups()
    {
       /* DataGroup personDataGroup = new()
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
        dataGroups.Add(contactDataGroup);*/

        return dataGroups;
    }

    public void Update(DataGroup dataGroup)
    {
        throw new NotImplementedException();
    }
}
