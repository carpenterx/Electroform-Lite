namespace ElectroformLite.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IDataGroupTypeRepository DataGroupTypeRepository { get; }
    public IDataTypeRepository DataTypeRepository { get; }
    public IDataRepository DataRepository { get; }
    public IDataGroupRepository DataGroupRepository { get; }
    public IDataTemplateRepository DataTemplateRepository { get; }

    Task Save();
}