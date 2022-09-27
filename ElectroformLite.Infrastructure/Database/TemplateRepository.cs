using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectroformLite.Infrastructure.Database;

public class TemplateRepository : ITemplateRepository
{
    private readonly ElectroformDbContext _context;

    public TemplateRepository(ElectroformDbContext context)
    {
        _context = context;
    }

    public void Create(Template template)
    {
        _context.Templates.Add(template);
    }

    public void Delete(Template template)
    {
        _context.Templates.Remove(template);
    }

    public Task<List<Template>> FindTemplates(string searchTerm)
    {
        throw new NotImplementedException();
    }

    public async Task<Template?> GetTemplate(Guid id)
    {
        Template? template = await _context.Templates
            .SingleOrDefaultAsync(t => t.Id == id);

        return template;
    }

    public async Task<Template?> GetTemplateWithDocuments(Guid id)
    {
        Template? template = await _context.Templates
            .Include(t => t.Documents)
            .SingleOrDefaultAsync(t => t.Id == id);

        return template;
    }

    public async Task<Template?> GetTemplateWithAliasTemplates(Guid id)
    {
        Template? template = await _context.Templates
            .Include(t => t.AliasTemplates)
            .ThenInclude(a => a.DataGroupTemplate)
            .ThenInclude(d => d.DataGroupType)
            //.Include(t => t.DataGroupTemplates)
            //.ThenInclude(d => d.DataGroups)
            .SingleOrDefaultAsync(t => t.Id == id);

        return template;
    }

    public async Task<List<Template>> GetTemplates()
    {
        return await _context.Templates.ToListAsync();
    }

    public void Update(Template template)
    {
        _context.Templates.Update(template);
    }
}
