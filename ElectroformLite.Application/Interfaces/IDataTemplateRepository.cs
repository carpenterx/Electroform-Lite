using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataTemplateRepository
{
    void Create(DataTemplate dataTemplate);
    void Delete(DataTemplate dataTemplate);
    void Update(DataTemplate dataTemplate);
    Task<DataTemplate?> GetDataTemplate(Guid id);
    Task<DataTemplate?> GetDataTemplateAndData(Guid id);
    Task<DataTemplate?> GetDataTemplateAndDataAndDataGroupTemplates(Guid id);
    Task<List<DataTemplate>> GetDataTemplates();
}
