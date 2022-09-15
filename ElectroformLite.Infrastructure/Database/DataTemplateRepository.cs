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
        DataTemplate? dataTemplate = await _context.DataTemplates
            .SingleOrDefaultAsync(d => d.Id == id);

        return dataTemplate;
    }

    public async Task<DataTemplate?> GetDataTemplateAndData(Guid id)
    {
        DataTemplate? dataTemplate = await _context.DataTemplates
            .Include(d => d.UserData)
            .SingleOrDefaultAsync(d => d.Id == id);

        return dataTemplate;
    }

    public async Task<DataTemplate?> GetDataTemplateAndDataAndDataGroupTemplates(Guid id)
    {
        DataTemplate? dataTemplate = await _context.DataTemplates
            .Include(d => d.UserData)
            .Include(d => d.DataGroupTemplates)
            .SingleOrDefaultAsync(d => d.Id == id);

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
