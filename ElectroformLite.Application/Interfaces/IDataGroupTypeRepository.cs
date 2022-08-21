using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataGroupTypeRepository
{
    void Create(DataGroupType dataGroupType);
    void Delete(Guid id);
    void Update(DataGroupType dataGroupType);
    DataGroupType GetDataGroupType(Guid id);
    List<DataGroupType> GetDataGroupTypes();
}
