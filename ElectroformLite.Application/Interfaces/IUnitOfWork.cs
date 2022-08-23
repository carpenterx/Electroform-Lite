namespace ElectroformLite.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IDataGroupTypeRepository DataGroupTypeRepository { get; }

    Task Save();
}