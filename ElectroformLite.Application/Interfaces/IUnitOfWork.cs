namespace ElectroformLite.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IDataGroupTypeRepository DataGroupTypeRepository { get; }
    public IDataTypeRepository DataTypeRepository { get; }
    public IDataRepository DataRepository { get; }

    Task Save();
}