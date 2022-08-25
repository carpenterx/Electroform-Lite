using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataTypeRepository
{
    void Create(DataType dataType);
    void Delete(DataType dataType);
    void Update(DataType dataType);
    Task<DataType?> GetDataType(Guid id);
    Task<List<DataType>> GetDataTypes();
}
