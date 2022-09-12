using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.Database;

public class AliasRepository : IAliasRepository
{
    private readonly ElectroformDbContext _context;

    public AliasRepository(ElectroformDbContext context)
    {
        _context = context;
    }

    public void Create(Alias alias)
    {
        _context.Aliases.Add(alias);
    }

    public void Delete(Alias alias)
    {
        throw new NotImplementedException();
    }

    public Task<Alias?> GetAlias(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Alias>> GetAliases()
    {
        throw new NotImplementedException();
    }

    public void Update(Alias alias)
    {
        throw new NotImplementedException();
    }
}
