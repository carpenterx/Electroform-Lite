using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.InMemory;

public class InMemoryDocumentRepository : IDocumentRepository
{
    readonly List<Document> documents = new();

    public void Create(Document document)
    {
        int previousId;
        if (documents.Count > 0)
        {
            previousId = documents[^1].Id;
        }
        else
        {
            previousId = -1;
        }
        document.Id = previousId + 1;
        documents.Add(document);
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Document GetDocument(int id)
    {
        throw new NotImplementedException();
    }

    public List<Document> GetDocuments()
    {
        /*Document document = new()
        {
            Id = 0,
            Name = "Document: Cerere Alocare Credentiale Pentru Plata Impozitelor Si Taxelor Locale Pentru Persoane Fizice",
            TemplateId = 0
        };

        documents.Add(document);*/

        return documents;
    }

    public void Update(Document document)
    {
        throw new NotImplementedException();
    }
}
