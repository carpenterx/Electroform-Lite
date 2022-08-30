using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectroformLite.Infrastructure.Database;

public class DataRepository : IDataRepository
{
    private readonly ElectroformDbContext _context;

    public DataRepository(ElectroformDbContext context)
    {
        _context = context;
    }

    public void Create(Data data)
    {
        _context.UserData.Add(data);
    }

    public void Delete(Data data)
    {
        _context.UserData.Remove(data);
    }

    public async Task<List<Data>> GetAllData()
    {
        return await _context.UserData.ToListAsync();
    }

    public async Task<Data?> GetData(Guid id)
    {
        Data? data = await _context.UserData.SingleOrDefaultAsync(d => d.Id == id);

        return data;
    }

    public void Update(Data data)
    {
        _context.Update(data);
    }
}
