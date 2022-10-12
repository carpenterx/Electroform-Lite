using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IAliasTemplateRepository
{
    void Create(AliasTemplate aliasTemplate);
    void Delete(AliasTemplate aliasTemplate);
    void Update(AliasTemplate aliasTemplate);
    Task<Guid?> GetAliasTemplateId(Guid dataGroupTemplateId);
    Task<AliasTemplate?> GetAliasTemplate(Guid id);
    Task<AliasTemplate?> GetAliasTemplateWithAliases(Guid id);
    Task<AliasTemplate?> GetAliasTemplateWithDataGroupTemplate(Guid id);
    Task<List<AliasTemplate>> GetAliasTemplates();
}
