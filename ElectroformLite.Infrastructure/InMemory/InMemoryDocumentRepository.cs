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
        Document document = documents.FirstOrDefault(d => d.Id == id);
        documents.Remove(document);
    }

    public Document GetDocument(int id)
    {
        return documents.FirstOrDefault(d => d.Id == id);
    }

    public List<Document> GetDocuments()
    {
        return documents;
    }

    public void Update(Document document)
    {
        throw new NotImplementedException();
    }
}
