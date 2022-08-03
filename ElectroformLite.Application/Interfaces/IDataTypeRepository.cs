using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataTypeRepository
{
    List<DataType> GetDataTypes();
}
