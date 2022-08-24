using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataGroupTypeRepository
{
    Task Create(DataGroupType dataGroupType);
    void Delete(DataGroupType dataGroupType);
    void Update(DataGroupType dataGroupType);
    Task<DataGroupType> GetDataGroupType(Guid id);
    Task<List<DataGroupType>> GetDataGroupTypes();
}
