using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IAliasTemplateRepository
{
    void Create(AliasTemplate aliasTemplate);
    void Delete(AliasTemplate aliasTemplate);
    void Update(AliasTemplate aliasTemplate);
    Task<AliasTemplate?> GetDataGroup(Guid id);
    Task<List<AliasTemplate>> GetDataGroupsByType(Guid id);
    Task<List<AliasTemplate>> GetDataGroups();
    Task<List<AliasTemplate>> GetDataGroupsWithIds(List<Guid> guids);
}
