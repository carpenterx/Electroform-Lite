using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataGroupTemplateRepository
{
    void Create(DataGroupTemplate dataGroupTemplate);
    void Delete(DataGroupTemplate dataGroupTemplate);
    void Update(DataGroupTemplate dataGroupTemplate);
    Task<DataGroupTemplate?> GetDataGroupTemplate(Guid id);
    Task<DataGroupTemplate?> GetDataGroupTemplateWithDataGroups(Guid id);
    Task<DataGroupTemplate?> GetDataGroupTemplateWithDataTemplates(Guid id);
    Task<DataGroupTemplate?> GetDataGroupTemplateWithDataGroupType(Guid id);
    Task<DataGroupTemplate?> GetDataGroupTemplateWithAliasTemplates(Guid id);
    Task<List<DataGroupTemplate>> GetDataGroupTemplates();
}
