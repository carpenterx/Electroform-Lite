using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.InMemory;

public class InMemoryDocumentRepository : IDocumentRepository
{
    readonly List<Document> documents = new();

    public void Create(Document document)
    {
        document.Id = Guid.NewGuid();
        documents.Add(document);
    }

    public void Delete(Guid id)
    {
        Document document = documents.FirstOrDefault(d => d.Id == id);
        documents.Remove(document);
    }

    public Document GetDocument(Guid id)
    {
        return documents.FirstOrDefault(d => d.Id == id);
    }

    public List<Document> GetDocuments()
    {
        return documents;
    }

    public void Update(Document document)
    {
        Document? documentToEdit = documents.FirstOrDefault(d => d.Id == document.Id);
        if (documentToEdit is not null)
        {
            documentToEdit.Name = document.Name;
            //documentToEdit.Content = document.Content;
        }
    }
}
