using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IAliasRepository
{
    void Create(Alias alias);
    void Delete(Alias alias);
    void Update(Alias alias);
    Task<Alias?> GetAlias(Guid id);
    Task<List<Alias>> GetAliases();
}
