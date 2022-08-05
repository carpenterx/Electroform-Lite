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
        throw new NotImplementedException();
    }

    public Template GetTemplate(int id)
    {
        return templates.FirstOrDefault(o => o.Id == id);
    }

    public List<Template> GetTemplates()
    {
        return templates;
    }

    public void Update(Template template)
    {
        throw new NotImplementedException();
    }
}
