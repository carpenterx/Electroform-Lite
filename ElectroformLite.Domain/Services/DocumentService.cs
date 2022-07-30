using ElectroformLite.Domain.Models;

namespace ElectroformLite.Domain.Services;

public class DocumentService
{
    public static List<Document> GetDocuments()
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
