using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

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

    public Task<AliasTemplate?> GetDataGroup(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<AliasTemplate>> GetDataGroups()
    {
        throw new NotImplementedException();
    }

    public Task<List<AliasTemplate>> GetDataGroupsByType(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<AliasTemplate>> GetDataGroupsWithIds(List<Guid> guids)
    {
        throw new NotImplementedException();
    }

    public void Update(AliasTemplate aliasTemplate)
    {
        throw new NotImplementedException();
    }
}
