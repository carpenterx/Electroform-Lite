using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectroformLite.Infrastructure.Database;

public class DataTypeRepository : IDataTypeRepository
{
    private readonly ElectroformDbContext _context;

    public DataTypeRepository(ElectroformDbContext context)
    {
        _context = context;
    }

    public void Create(DataType dataType)
    {
        _context.DataTypes.Add(dataType);
    }

    public void Delete(DataType dataType)
    {
        _context.DataTypes.Remove(dataType);
    }

    public async Task<DataType?> GetDataType(Guid id)
    {
        DataType? dataType = await _context.DataTypes.SingleOrDefaultAsync(p => p.Id == id);

        return dataType;
    }

    public async Task<List<DataType>> GetDataTypes()
    {
        return await _context.DataTypes.ToListAsync();
    }

    public void Update(DataType dataType)
    {
        _context.Update(dataType);
    }
}
