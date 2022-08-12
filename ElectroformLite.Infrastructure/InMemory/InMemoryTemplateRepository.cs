using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.InMemory;

public class InMemoryTemplateRepository : ITemplateRepository
{
    readonly List<Template> templates = new();

    public void Create(Template template)
    {
        int previousId;
        if (templates.Count > 0)
        {
            previousId = templates[^1].Id;
        }
        else
        {
            previousId = -1;
        }
        template.Id = previousId + 1;
        templates.Add(template);
    }

    public void Delete(int id)
    {
        Template template = templates.FirstOrDefault(d => d.Id == id);
        templates.Remove(template);
    }

    public List<Template> FindTemplates(string searchTerm)
    {
        string lowercaseSearchTerm = searchTerm.ToLowerInvariant();
        return templates.FindAll(t => t.Name.ToLowerInvariant().Contains(lowercaseSearchTerm) || t.Content.ToLowerInvariant().Contains(lowercaseSearchTerm));
    }

    public Template GetTemplate(int id)
    {
        return templates.FirstOrDefault(t => t.Id == id);
    }

    public List<Template> GetTemplates()
    {
        return templates;
    }

    public void Update(Template template)
    {
        Template? templateToUpdate = templates.FirstOrDefault(d => d.Id == template.Id);
        if (templateToUpdate is null)
        {
            throw new InvalidOperationException($"Template with id {template.Id} not found");
        }
        templateToUpdate.Name = template.Name;
        templateToUpdate.Content = template.Content;
        templateToUpdate.DataGroupTemplates = template.DataGroupTemplates;
    }
}
