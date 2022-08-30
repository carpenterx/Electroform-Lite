using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectroformLite.Infrastructure.Database;

public class DataGroupTemplateRepository : IDataGroupTemplateRepository
{
    private readonly ElectroformDbContext _context;

    public DataGroupTemplateRepository(ElectroformDbContext context)
    {
        _context = context;
    }

    public void Create(DataGroupTemplate dataGroupTemplate)
    {
        _context.DataGroupTemplates.Add(dataGroupTemplate);
    }

    public void Delete(DataGroupTemplate dataGroupTemplate)
    {
        _context.DataGroupTemplates.Remove(dataGroupTemplate);
    }

    public async Task<DataGroupTemplate?> GetDataGroupTemplate(Guid id)
    {
        DataGroupTemplate? dataGroupTemplate = await _context.DataGroupTemplates
            .Include(d => d.DataGroups)
            .SingleOrDefaultAsync(d => d.Id == id);

        return dataGroupTemplate;
    }

    public async Task<List<DataGroupTemplate>> GetDataGroupTemplates()
    {
        return await _context.DataGroupTemplates.ToListAsync();
    }

    public void Update(DataGroupTemplate dataGroupTemplate)
    {
        _context.DataGroupTemplates.Update(dataGroupTemplate);
    }
}
