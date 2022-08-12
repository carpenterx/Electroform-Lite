using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.InMemory;

public class InMemoryDataTypeRepository : IDataTypeRepository
{
    readonly List<DataType> dataTypes = new();

    public void Create(DataType dataType)
    {
        int previousId;
        if (dataTypes.Count > 0)
        {
            previousId = dataTypes[^1].Id;
        }
        else
        {
            previousId = -1;
        }
        dataType.Id = previousId + 1;
        dataTypes.Add(dataType);
    }

    public void Delete(int id)
    {
        DataType dataType = dataTypes.FirstOrDefault(d => d.Id == id);
        dataTypes.Remove(dataType);
    }

    public DataType GetDataType(int id)
    {
        return dataTypes.FirstOrDefault(d => d.Id == id);
    }

    public List<DataType> GetDataTypes()
    {
        return dataTypes;
    }

    public void Update(DataType dataType)
    {
        DataType? dataTypeToEdit = dataTypes.FirstOrDefault(d => d.Id == dataType.Id);
        if (dataTypeToEdit is not null)
        {
            dataTypeToEdit.Value = dataType.Value;
        }
    }
}
