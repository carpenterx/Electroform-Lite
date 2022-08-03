using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.InMemory;

public class InMemoryDataTypeRepository : IDataTypeRepository
{
    public List<DataType> GetDataTypes()
    {
        List<DataType> dataTypes = new();

        DataType textDataType = new() { Id = 0, Value = "Text" };
        dataTypes.Add(textDataType);

        DataType phoneDataType = new() { Id = 1, Value = "Phone" };
        dataTypes.Add(phoneDataType);

        DataType emailDataType = new() { Id = 2, Value = "Email" };
        dataTypes.Add(emailDataType);

        return dataTypes;
    }
}
