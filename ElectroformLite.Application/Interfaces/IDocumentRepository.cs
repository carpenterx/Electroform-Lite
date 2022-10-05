using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDocumentRepository
{
    void Create(Document document);
    void Delete(Document document);
    void Update(Document document);
    Task<int> GetCount();
    Task<Document?> GetDocument(Guid id);
    Task<List<Document>> GetDocuments(int pageNumber, int pageSize);
}
