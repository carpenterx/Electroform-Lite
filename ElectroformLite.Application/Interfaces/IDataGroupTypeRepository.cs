using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataGroupTypeRepository
{
    void Create(DataGroupType dataGroupType);
    void Delete(int id);
    void Update(DataGroupType dataGroupType);
    Data GetData(int id);
    List<DataGroupType> GetDataGroupTypes();
}
