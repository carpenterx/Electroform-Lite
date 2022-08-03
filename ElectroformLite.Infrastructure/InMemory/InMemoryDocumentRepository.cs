using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.InMemory;

public class InMemoryDocumentRepository : IDocumentRepository
{
    public List<Document> GetDocuments()
    {
        List<Document> documents = new();

        Document document = new()
        {
            Id = 0,
            Name = "Document: Cerere Alocare Credentiale Pentru Plata Impozitelor Si Taxelor Locale Pentru Persoane Fizice",
            TemplateId = 0
        };

        documents.Add(document);

        return documents;
    }
}
