using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataGroupRepository
{
    void Create(DataGroup dataGroup);
    void Delete(DataGroup dataGroup);
    void Update(DataGroup dataGroup);
    Task<DataGroup?> GetDataGroup(Guid id);
    Task<List<DataGroup>> GetDataGroupsByType(Guid id);
    Task<List<DataGroup>> GetDataGroups();
    Task<List<DataGroup>> GetDataGroupsWithIds(List<Guid> guids);
}
