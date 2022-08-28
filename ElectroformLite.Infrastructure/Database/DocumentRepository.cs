using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectroformLite.Infrastructure.Database;

public class DocumentRepository : IDocumentRepository
{
    private readonly ElectroformDbContext _context;

    public DocumentRepository(ElectroformDbContext context)
    {
        _context = context;
    }

    public void Create(Document document)
    {
        _context.Documents.Add(document);
    }

    public void Delete(Document document)
    {
        _context.Documents.Remove(document);
    }

    public async Task<Document?> GetDocument(Guid id)
    {
        Document? document = await _context.Documents.Include(d => d.DataGroups).SingleOrDefaultAsync(d => d.Id == id);

        return document;
    }

    public async Task<List<Document>> GetDocuments()
    {
        return await _context.Documents.Include(d => d.DataGroups).ToListAsync();
    }

    public void Update(Document document)
    {
        _context.Documents.Update(document);
    }
}
