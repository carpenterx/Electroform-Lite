using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataGroupTemplateRepository
{
    void Create(DataGroupTemplate dataGroupTemplate);
    void Delete(int id);
    void Update(DataGroupTemplate dataGroupTemplate);
    DataGroupTemplate GetDataGroupTemplate(int id);
    List<DataGroupTemplate> GetDataGroupTemplates();
}
