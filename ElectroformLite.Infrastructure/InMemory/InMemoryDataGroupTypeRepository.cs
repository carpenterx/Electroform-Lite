using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.InMemory;

public class InMemoryDataGroupTypeRepository : IDataGroupTypeRepository
{
    readonly List<DataGroupType> dataGroupTypes = new();

    public void Create(DataGroupType dataGroupType)
    {
        int previousId;
        if (dataGroupTypes.Count > 0)
        {
            previousId = dataGroupTypes[^1].Id;
        }
        else
        {
            previousId = -1;
        }
        dataGroupType.Id = previousId + 1;
        dataGroupTypes.Add(dataGroupType);
    }

    public void Delete(int id)
    {
        DataGroupType dataGroupType = dataGroupTypes.FirstOrDefault(d => d.Id == id);
        dataGroupTypes.Remove(dataGroupType);
    }

    public DataGroupType GetDataGroupType(int id)
    {
        return dataGroupTypes.FirstOrDefault(d => d.Id == id);
    }

    public List<DataGroupType> GetDataGroupTypes()
    {
        return dataGroupTypes;
    }

    public void Update(DataGroupType dataGroupType)
    {
        DataGroupType? dataGroupTypeToEdit = dataGroupTypes.FirstOrDefault(d => d.Id == dataGroupType.Id);
        if (dataGroupTypeToEdit is not null)
        {
            dataGroupTypeToEdit.Value = dataGroupType.Value;
        }
    }
}
