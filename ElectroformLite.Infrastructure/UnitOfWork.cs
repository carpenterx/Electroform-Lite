using ElectroformLite.Application.Interfaces;
using ElectroformLite.Infrastructure.Database;

namespace ElectroformLite.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    public IDataGroupTypeRepository DataGroupTypeRepository { get; private set; }

    private readonly ElectroformDbContext _dbContext;

    public UnitOfWork(ElectroformDbContext dbContext, IDataGroupTypeRepository dataGroupTypeRepository)
    {
        _dbContext = dbContext;
        DataGroupTypeRepository = dataGroupTypeRepository;
    }

    public async Task Save()
    {
        await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}
