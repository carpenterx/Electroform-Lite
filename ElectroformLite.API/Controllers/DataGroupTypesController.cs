using ElectroformLite.Domain.Models;
using ElectroformLite.Infrastructure.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectroformLite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataGroupTypesController : ControllerBase
    {
        private readonly ElectroformDbContext _dbContext;
        public DataGroupTypesController(ElectroformDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet(Name = "GetDataGroupTypes")]
        public async Task<List<DataGroupType>> Get()
        {
            return await _dbContext.DataGroupTypes.ToListAsync();
        }

        [HttpPost(Name = "CreateDataGroupType")]
        public async Task Post()
        {
            DataGroupType dataGroupType = new("MyType");
            await _dbContext.DataGroupTypes.AddAsync(dataGroupType);
            await _dbContext.SaveChangesAsync();
        }
    }
}
