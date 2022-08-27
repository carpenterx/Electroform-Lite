using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectroformLite.Infrastructure.Database;

public class DataTemplateRepository : IDataTemplateRepository
{
    private readonly ElectroformDbContext _context;

    public DataTemplateRepository(ElectroformDbContext context)
    {
        _context = context;
    }

    public void Create(DataTemplate dataTemplate)
    {
        _context.DataTemplates.Add(dataTemplate);
    }

    public void Delete(DataTemplate dataTemplate)
    {
        _context.DataTemplates.Remove(dataTemplate);
    }

    public async Task<DataTemplate?> GetDataTemplate(Guid id)
    {
        DataTemplate? dataTemplate = await _context.DataTemplates.SingleOrDefaultAsync(d => d.Id == id);

        return dataTemplate;
    }

    public async Task<List<DataTemplate>> GetDataTemplates()
    {
        return await _context.DataTemplates.ToListAsync();
    }

    public void Update(DataTemplate dataTemplate)
    {
        _context.DataTemplates.Update(dataTemplate);
    }
}
