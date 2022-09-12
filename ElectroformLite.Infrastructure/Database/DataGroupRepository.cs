using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectroformLite.Infrastructure.Database;

public class DataGroupRepository : IDataGroupRepository
{
    private readonly ElectroformDbContext _context;

    public DataGroupRepository(ElectroformDbContext context)
    {
        _context = context;
    }

    public void Create(DataGroup dataGroup)
    {
        _context.DataGroups.Add(dataGroup);
    }

    public void Delete(DataGroup dataGroup)
    {
        _context.DataGroups.Remove(dataGroup);
    }

    public async Task<DataGroup?> GetDataGroup(Guid id)
    {
        DataGroup? dataGroup = await _context.DataGroups
            .Include(d => d.Aliases)
            .Include(d => d.UserData)
            .ThenInclude(u => u.DataTemplate)
            .SingleOrDefaultAsync(d => d.Id == id);

        return dataGroup;
    }

    public async Task<List<DataGroup>> GetDataGroupsWithIds(List<Guid> guids)
    {
        return await _context.DataGroups
            .Include(d => d.UserData)
            .ThenInclude(u => u.DataTemplate)
            .Where(d => guids.Contains( d.Id))
            .ToListAsync();
    }

    public async Task<List<DataGroup>> GetDataGroups()
    {
        return await _context.DataGroups.Include(d => d.UserData).ToListAsync();
    }

    public Task<List<DataGroup>> GetDataGroupsByType(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Update(DataGroup dataGroup)
    {
        _context.Update(dataGroup);
    }
}
