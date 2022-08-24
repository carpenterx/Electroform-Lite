using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.Database;

public class TemplateRepository : ITemplateRepository
{
    public void Create(Template template)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Template> FindTemplates(string searchTerm)
    {
        throw new NotImplementedException();
    }

    public Template GetTemplate(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Template> GetTemplates()
    {
        throw new NotImplementedException();
    }

    public void Update(Template template)
    {
        throw new NotImplementedException();
    }
}
