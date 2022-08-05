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

    public Data GetData(int id)
    {
        throw new NotImplementedException();
    }

    public List<DataType> GetDataTypes()
    {
        /*DataType textDataType = new() { Id = 0, Value = "Text" };
        dataTypes.Add(textDataType);

        DataType phoneDataType = new() { Id = 1, Value = "Phone" };
        dataTypes.Add(phoneDataType);

        DataType emailDataType = new() { Id = 2, Value = "Email" };
        dataTypes.Add(emailDataType);*/

        return dataTypes;
    }

    public void Update(DataType dataType)
    {
        throw new NotImplementedException();
    }
}
