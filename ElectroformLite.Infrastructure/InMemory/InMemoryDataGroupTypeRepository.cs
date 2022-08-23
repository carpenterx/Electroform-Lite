using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.InMemory;

public class InMemoryDataGroupTypeRepository : IDataGroupTypeRepository
{
    readonly List<DataGroupType> dataGroupTypes = new();

    public async Task Create(DataGroupType dataGroupType)
    {
        dataGroupType.Id = Guid.NewGuid();
        dataGroupTypes.Add(dataGroupType);
    }

    public void Delete(Guid id)
    {
        DataGroupType dataGroupType = dataGroupTypes.FirstOrDefault(d => d.Id == id);
        dataGroupTypes.Remove(dataGroupType);
    }

    public DataGroupType GetDataGroupType(Guid id)
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
