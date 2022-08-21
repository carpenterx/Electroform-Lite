using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.InMemory;

public class InMemoryDataGroupRepository : IDataGroupRepository
{
    readonly List<DataGroup> dataGroups = new();

    public void Create(DataGroup dataGroup)
    {
        dataGroup.Id = Guid.NewGuid();
        dataGroups.Add(dataGroup);
    }

    public void Delete(Guid id)
    {
        DataGroup dataGroup = dataGroups.FirstOrDefault(d => d.Id == id);
        dataGroups.Remove(dataGroup);
    }

    public DataGroup GetDataGroup(Guid id)
    {
        return dataGroups.FirstOrDefault(d => d.Id == id);
    }

    public List<DataGroup> GetDataGroups()
    {
        return dataGroups;
    }

    public List<DataGroup> GetDataGroupsByType(Guid id)
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
