using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface ITemplateRepository
{
    List<Template> GetTemplates();
}
