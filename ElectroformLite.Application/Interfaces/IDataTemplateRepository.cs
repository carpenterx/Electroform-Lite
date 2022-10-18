using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataTemplateRepository
{
    void Create(DataTemplate dataTemplate);
    void Delete(DataTemplate dataTemplate);
    void Update(DataTemplate dataTemplate);
    Task<DataTemplate?> GetDataTemplate(Guid id);
    Task<DataTemplate?> GetDataTemplateWithData(Guid id);
    Task<DataTemplate?> GetDataTemplateWithDataAndDataGroupTemplates(Guid id);
    Task<List<DataTemplate>> GetDataTemplates();
}
