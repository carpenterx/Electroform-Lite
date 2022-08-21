using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.InMemory;

public class InMemoryDataTypeRepository : IDataTypeRepository
{
    readonly List<DataType> dataTypes = new();

    public void Create(DataType dataType)
    {
        dataType.Id = Guid.NewGuid();
        dataTypes.Add(dataType);
    }

    public void Delete(Guid id)
    {
        DataType dataType = dataTypes.FirstOrDefault(d => d.Id == id);
        dataTypes.Remove(dataType);
    }

    public DataType GetDataType(Guid id)
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
