﻿using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.Database
{
    public class DataGroupTypeRepository : IDataGroupTypeRepository
    {
        private readonly ElectroformDbContext _context;

        public DataGroupTypeRepository(ElectroformDbContext context)
        {
            _context = context;
        }

        public async Task Create(DataGroupType dataGroupType)
        {
            await _context.DataGroupTypes.AddAsync(dataGroupType);
            //await _context.SaveChangesAsync();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public DataGroupType GetDataGroupType(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<DataGroupType> GetDataGroupTypes()
        {
            throw new NotImplementedException();
        }

        public void Update(DataGroupType dataGroupType)
        {
            throw new NotImplementedException();
        }
    }
}
