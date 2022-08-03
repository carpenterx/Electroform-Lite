using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataTemplateRepository
{
    List<DataTemplate> GetDataTemplates();
}
