using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface ITemplateRepository
{
    void Create(Template template);
    void Delete(Guid id);
    void Update(Template template);
    Template GetTemplate(Guid id);
    List<Template> FindTemplates(string searchTerm);
    List<Template> GetTemplates();
}
