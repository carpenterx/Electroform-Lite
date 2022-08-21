using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDocumentRepository
{
    void Create(Document document);
    void Delete(Guid id);
    void Update(Document document);
    Document GetDocument(Guid id);
    List<Document> GetDocuments();
}
