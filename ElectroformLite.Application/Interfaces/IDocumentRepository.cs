using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDocumentRepository
{
    List<Document> GetDocuments();
}
