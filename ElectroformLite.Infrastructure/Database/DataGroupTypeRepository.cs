﻿using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectroformLite.Infrastructure.Database
{
    public class DataGroupTypeRepository : IDataGroupTypeRepository
    {
        private readonly ElectroformDbContext _context;

        public DataGroupTypeRepository(ElectroformDbContext context)
        {
            _context = context;
        }

        public void Create(DataGroupType dataGroupType)
        {
            _context.DataGroupTypes.Add(dataGroupType);
        }

        public void Delete(DataGroupType dataGroupType)
        {
            _context.DataGroupTypes.Remove(dataGroupType);
        }

        public async Task<DataGroupType?> GetDataGroupType(Guid id)
        {
            DataGroupType? dataGroupType = await _context.DataGroupTypes
                .SingleOrDefaultAsync(d => d.Id == id);

            return dataGroupType;
        }

        public async Task<DataGroupType?> GetFullDataGroupType(Guid id)
        {
            DataGroupType? dataGroupType = await _context.DataGroupTypes
                .Include(d => d.DataGroupTemplates)
                .SingleOrDefaultAsync(d => d.Id == id);

            return dataGroupType;
        }

        public async Task<List<DataGroupType>> GetDataGroupTypes()
        {
            return await _context.DataGroupTypes.ToListAsync();
        }

        public void Update(DataGroupType dataGroupType)
        {
            _context.Update(dataGroupType);
        }
    }
}
