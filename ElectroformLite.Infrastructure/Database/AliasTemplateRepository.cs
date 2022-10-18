using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectroformLite.Infrastructure.Database;

public class AliasTemplateRepository : IAliasTemplateRepository
{
    private readonly ElectroformDbContext _context;

    public AliasTemplateRepository(ElectroformDbContext context)
    {
        _context = context;
    }

    public void Create(AliasTemplate aliasTemplate)
    {
        _context.AliasTemplates.Add(aliasTemplate);
    }

    public void Delete(AliasTemplate aliasTemplate)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid?> GetAliasTemplateId(Guid dataGroupTemplateId)
    {
        AliasTemplate? aliasTemplate = await _context.AliasTemplates
            .SingleOrDefaultAsync(a => a.DataGroupTemplateId == dataGroupTemplateId);

        return aliasTemplate?.Id;
    }

    public async Task<AliasTemplate?> GetAliasTemplate(Guid id)
    {
        AliasTemplate? aliasTemplate = await _context.AliasTemplates
            //.Include(a => a.Aliases)
            .SingleOrDefaultAsync(a => a.Id == id);

        return aliasTemplate;
    }

    public async Task<AliasTemplate?> GetAliasTemplateWithAliases(Guid id)
    {
        AliasTemplate? aliasTemplate = await _context.AliasTemplates
            .Include(a => a.Aliases)
            .SingleOrDefaultAsync(a => a.Id == id);

        return aliasTemplate;
    }

    public async Task<AliasTemplate?> GetAliasTemplateWithDataGroupTemplate(Guid id)
    {
        AliasTemplate? aliasTemplate = await _context.AliasTemplates
            .Include(a => a.DataGroupTemplate)
            .ThenInclude(d => d.DataTemplates)
            .SingleOrDefaultAsync(a => a.Id == id);

        return aliasTemplate;
    }

    public async Task<List<AliasTemplate>> GetAliasTemplates()
    {
        return await _context.AliasTemplates
            .Include(a => a.DataGroupTemplate)
            .ThenInclude(d => d.DataTemplates)
            //.ThenInclude(d => d.DataGroupType)
            .ToListAsync();
    }

    public void Update(AliasTemplate aliasTemplate)
    {
        throw new NotImplementedException();
    }
}
