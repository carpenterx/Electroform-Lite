using ElectroformLite.Application.Interfaces;
using ElectroformLite.Infrastructure.Database;

namespace ElectroformLite.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    public IDataGroupTypeRepository DataGroupTypeRepository { get; private set; }
    public IDataTypeRepository DataTypeRepository { get; private set; }
    public IDataRepository DataRepository { get; private set; }
    public IDataGroupRepository DataGroupRepository { get; private set; }
    public IDataTemplateRepository DataTemplateRepository { get; private set; }
    public IDataGroupTemplateRepository DataGroupTemplateRepository { get; private set; }

    private readonly ElectroformDbContext _dbContext;

    public UnitOfWork(ElectroformDbContext dbContext, IDataGroupTypeRepository dataGroupTypeRepository, IDataTypeRepository dataTypeRepository, IDataRepository dataRepository, IDataGroupRepository dataGroupRepository, IDataTemplateRepository dataTemplateRepository, IDataGroupTemplateRepository dataGroupTemplateRepository)
    {
        _dbContext = dbContext;
        DataGroupTypeRepository = dataGroupTypeRepository;
        DataTypeRepository = dataTypeRepository;
        DataRepository = dataRepository;
        DataGroupRepository = dataGroupRepository;
        DataTemplateRepository = dataTemplateRepository;
        DataGroupTemplateRepository = dataGroupTemplateRepository;
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
