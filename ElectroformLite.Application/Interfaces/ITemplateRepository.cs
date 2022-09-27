using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface ITemplateRepository
{
    void Create(Template template);
    void Delete(Template template);
    void Update(Template template);
    Task<Template?> GetTemplate(Guid id);
    Task<Template?> GetTemplateWithDocuments(Guid id);
    Task<Template?> GetTemplateWithAliasTemplates(Guid id);
    Task<List<Template>> FindTemplates(string searchTerm);
    Task<List<Template>> GetTemplates();
}
