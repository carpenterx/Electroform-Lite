using ElectroformLite.Application.DataGroupTypes.Queries.GetDataGroupTypes;
using ElectroformLite.Domain.Models;
using ElectroformLite.Infrastructure.Database;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectroformLite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataGroupTypesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DataGroupTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetDataGroupTypes")]
        public async Task<List<DataGroupType>> Get()
        {
            return await _mediator.Send(new GetDataGroupTypesQuery());
        }

        [HttpPost(Name = "CreateDataGroupType")]
        public async Task Post()
        {
            DataGroupType dataGroupType = new("MyType");
            //await _mediator.DataGroupTypes.AddAsync(dataGroupType);
            //await _mediator.SaveChangesAsync();
        }
    }
}
