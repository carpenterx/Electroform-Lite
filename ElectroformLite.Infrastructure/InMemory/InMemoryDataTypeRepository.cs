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
        throw new NotImplementedException();
    }

    public DataType GetDataType(int id)
    {
        throw new NotImplementedException();
    }

    public List<DataType> GetDataTypes()
    {
        return dataTypes;
    }

    public void Update(DataType dataType)
    {
        throw new NotImplementedException();
    }
}
