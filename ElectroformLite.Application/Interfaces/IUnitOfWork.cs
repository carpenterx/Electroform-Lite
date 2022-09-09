namespace ElectroformLite.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IDataGroupTypeRepository DataGroupTypeRepository { get; }
    public IDataTypeRepository DataTypeRepository { get; }
    public IDataRepository DataRepository { get; }
    public IDataGroupRepository DataGroupRepository { get; }
    public IDataTemplateRepository DataTemplateRepository { get; }
    public IDataGroupTemplateRepository DataGroupTemplateRepository { get; }
    public ITemplateRepository TemplateRepository { get; }
    public IDocumentRepository DocumentRepository { get; }
    public IAliasTemplateRepository AliasTemplateRepository { get; }
    public IAliasRepository AliasRepository { get; }

    Task Save();
}