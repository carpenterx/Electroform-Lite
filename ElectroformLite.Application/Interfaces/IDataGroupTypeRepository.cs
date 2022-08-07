using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataGroupTypeRepository
{
    void Create(DataGroupType dataGroupType);
    void Delete(int id);
    void Update(DataGroupType dataGroupType);
    DataGroupType GetDataGroupType(int id);
    List<DataGroupType> GetDataGroupTypes();
}
