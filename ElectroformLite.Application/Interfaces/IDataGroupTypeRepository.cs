using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataGroupTypeRepository
{
    Task Create(DataGroupType dataGroupType);
    void Delete(Guid id);
    void Update(DataGroupType dataGroupType);
    DataGroupType GetDataGroupType(Guid id);
    Task<List<DataGroupType>> GetDataGroupTypes();
}
