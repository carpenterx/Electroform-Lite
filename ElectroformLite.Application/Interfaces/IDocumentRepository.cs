using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDocumentRepository
{
    void Create(Document document);
    void Delete(int id);
    void Update(Document document);
    Document GetDocument(int id);
    List<Document> GetDocuments();
}
