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
        Document? document = await _context.Documents
            .Include(d => d.Aliases)
            .SingleOrDefaultAsync(d => d.Id == id);

        return document;
    }

    public async Task<int> GetCount()
    {
        return await _context.Documents.CountAsync();
    }

    /*public async Task<List<Document>> GetDocuments()
    {
        return await _context.Documents.Include(d => d.Aliases).ToListAsync();
    }*/

    public async Task<List<Document>> GetDocuments(int pageNumber, int pageSize)
    {
        return await _context.Documents
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Include(d => d.Aliases)
            .ToListAsync();
    }

    public void Update(Document document)
    {
        _context.Documents.Update(document);
    }
}
