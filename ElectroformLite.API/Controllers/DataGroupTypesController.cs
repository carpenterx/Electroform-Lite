using ElectroformLite.Application.DataGroupTypes.Commands.CreateDataGroupType;
using ElectroformLite.Application.DataGroupTypes.Queries.GetDataGroupTypes;
using ElectroformLite.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElectroformLite.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            await _mediator.Send(new CreateDataGroupTypeCommand("Person"));
        }
    }
}
