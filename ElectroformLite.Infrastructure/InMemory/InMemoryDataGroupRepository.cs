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
        DataGroup dataGroup = dataGroups.FirstOrDefault(d => d.Id == id);
        dataGroups.Remove(dataGroup);
    }

    public DataGroup GetDataGroup(int id)
    {
        return dataGroups.FirstOrDefault(d => d.Id == id);
    }

    public List<DataGroup> GetDataGroups()
    {
        return dataGroups;
    }

    public List<DataGroup> GetDataGroupsByType(int id)
    {
        return dataGroups.FindAll(d => d.Type == id);
    }

    public void Update(DataGroup dataGroup)
    {
        DataGroup? dataGroupToEdit = dataGroups.FirstOrDefault(d => d.Id == dataGroup.Id);
        if (dataGroupToEdit is not null)
        {
            dataGroupToEdit.Name = dataGroup.Name;
            dataGroupToEdit.Data = dataGroup.Data;
        }
    }
}
