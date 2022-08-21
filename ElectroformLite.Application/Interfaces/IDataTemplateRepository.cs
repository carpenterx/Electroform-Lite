using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataTemplateRepository
{
    void Create(DataTemplate dataTemplate);
    void Delete(Guid id);
    void Update(DataTemplate dataTemplate);
    DataTemplate GetDataTemplate(Guid id);
    List<DataTemplate> GetDataTemplates();
}
