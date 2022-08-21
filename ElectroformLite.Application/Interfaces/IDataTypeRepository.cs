using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataTypeRepository
{
    void Create(DataType dataType);
    void Delete(Guid id);
    void Update(DataType dataType);
    DataType GetDataType(Guid id);
    List<DataType> GetDataTypes();
}
