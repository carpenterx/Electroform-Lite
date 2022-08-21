using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataGroupTemplateRepository
{
    void Create(DataGroupTemplate dataGroupTemplate);
    void Delete(Guid id);
    void Update(DataGroupTemplate dataGroupTemplate);
    DataGroupTemplate GetDataGroupTemplate(Guid id);
    List<DataGroupTemplate> GetDataGroupTemplates();
}
