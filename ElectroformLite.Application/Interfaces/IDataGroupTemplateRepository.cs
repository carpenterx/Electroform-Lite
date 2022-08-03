using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataGroupTemplateRepository
{
    List<DataGroupTemplate> GetDataGroupTemplates();
}
