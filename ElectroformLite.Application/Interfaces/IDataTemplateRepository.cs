using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataTemplateRepository
{
    void Create(DataTemplate dataTemplate);
    void Delete(int id);
    void Update(DataTemplate dataTemplate);
    DataTemplate GetDataTemplate(int id);
    List<DataTemplate> GetDataTemplates();
}
