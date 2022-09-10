using AutoMapper;
using ElectroformLite.API.Dto;
using ElectroformLite.Application.DataGroupTypes.Commands.CreateDataGroupType;
using ElectroformLite.Application.DataGroupTypes.Commands.DeleteDataGroupType;
using ElectroformLite.Application.DataGroupTypes.Commands.EditDataGroupType;
using ElectroformLite.Application.DataGroupTypes.Queries.GetDataGroupType;
using ElectroformLite.Application.DataGroupTypes.Queries.GetDataGroupTypes;
using ElectroformLite.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElectroformLite.API.Controllers;

[ApiController]
[Route("data-group-types")]
public class DataGroupTypesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public DataGroupTypesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    // GET: data-group-types
    [HttpGet]
    public async Task<ActionResult<List<DataGroupType>>> GetDataGroupTypes()
    {
        List<DataGroupType> dataGroupTypes = await _mediator.Send(new GetDataGroupTypesQuery());
        List<DataGroupTypeDto> dataGroupTypeDtos = _mapper.Map<List<DataGroupTypeDto>>(dataGroupTypes);

        return Ok(dataGroupTypeDtos);
    }

    // GET: data-group-types/5
    [HttpGet("{id}")]
    public async Task<ActionResult<DataGroupType>> GetDataGroupType([FromRoute] Guid id)
    {
        DataGroupType? dataGroupType = await _mediator.Send(new GetDataGroupTypeQuery(id));

        if (dataGroupType == null)
        {
            return NotFound();
        }
        DataGroupTypeDto dataGroupTypeDto = _mapper.Map<DataGroupTypeDto>(dataGroupType);

        return Ok(dataGroupTypeDto);
    }

    // POST: data-group-types
    [HttpPost]
    public async Task<IActionResult> CreateDataGroupType([FromBody] string type)
    {
        DataGroupType dataGroupType = await _mediator.Send(new CreateDataGroupTypeCommand(type));

        DataGroupTypeDto dataGroupTypeDto = _mapper.Map<DataGroupTypeDto>(dataGroupType);

        return CreatedAtAction(nameof(GetDataGroupType), new { dataGroupTypeDto.Id }, dataGroupTypeDto);
    }

    // DELETE: data-group-types/5
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteDataGroupType([FromRoute] Guid id)
    {
        DataGroupType? dataGroupType = await _mediator.Send(new DeleteDataGroupTypeCommand(id));

        if (dataGroupType == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    // PUT: data-group-types/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDataGroupType([FromRoute] Guid id,[FromBody] DataGroupTypeDto dataGroupTypeDto)
    {
        if (id != dataGroupTypeDto.Id)
        {
            return BadRequest();
        }

        DataGroupType dataGroupTypeFromDto = _mapper.Map<DataGroupType>(dataGroupTypeDto);

        DataGroupType? editedDataGroupType = await _mediator.Send(new EditDataGroupTypeCommand(dataGroupTypeFromDto));

        if (editedDataGroupType == null)
        {
            return NotFound();
        }

        return NoContent();
    }
}
