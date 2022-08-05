using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataTypeRepository
{
    void Create(DataType dataType);
    void Delete(int id);
    void Update(DataType dataType);
    Data GetDataType(int id);
    List<DataType> GetDataTypes();
}
