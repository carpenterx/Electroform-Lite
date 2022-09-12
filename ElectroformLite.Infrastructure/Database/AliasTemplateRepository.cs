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

    public async Task<AliasTemplate?> GetAliasTemplate(Guid id)
    {
        AliasTemplate? aliasTemplate = await _context.AliasTemplates
            .Include(a => a.Aliases)
            .SingleOrDefaultAsync(a => a.Id == id);

        return aliasTemplate;
    }

    public Task<List<AliasTemplate>> GetAliasTemplates()
    {
        throw new NotImplementedException();
    }

    public void Update(AliasTemplate aliasTemplate)
    {
        throw new NotImplementedException();
    }
}
