using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataGroupTypeRepository
{
    void Create(DataGroupType dataGroupType);
    void Delete(int id);
    void Update(DataGroupType dataGroupType);
    Data GetDataGroupType(int id);
    List<DataGroupType> GetDataGroupTypes();
}
