using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataGroupRepository
{
    void Create(DataGroup dataGroup);
    void Delete(DataGroup dataGroup);
    void Update(DataGroup dataGroup);
    Task<DataGroup?> GetDataGroup(Guid id);
    Task<DataGroup?> GetDataGroupWithData(Guid id);
    Task<DataGroup?> GetDataGroupWithDataAndAliases(Guid id);
    Task<List<DataGroup>> GetDataGroupsByType(Guid dataGroupTypeId);
    Task<List<DataGroup>> GetDataGroups();
    Task<List<DataGroup>> GetDataGroupsWithIds(List<Guid> guids);
}
