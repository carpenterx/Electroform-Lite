using AutoMapper;
using ElectroformLite.Application.DataTypes.Commands.CreateDataType;
using ElectroformLite.Application.DataTypes.Commands.DeleteDataType;
using ElectroformLite.Application.DataTypes.Commands.EditDataType;
using ElectroformLite.Application.DataTypes.Queries.GetDataType;
using ElectroformLite.Application.DataTypes.Queries.GetDataTypes;
using ElectroformLite.Application.Dto;
using ElectroformLite.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectroformLite.API.Controllers;

[ApiController]
[Route("data-types")]
public class DataTypesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public DataTypesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    // GET: data-types
    [Authorize]
    [HttpGet]
    public async Task<ActionResult> GetDataTypes()
    {
        List<DataType> dataTypes = await _mediator.Send(new GetDataTypesQuery());
        List<DataTypeDto> dataTypeDtos = _mapper.Map<List<DataTypeDto>>(dataTypes);

        return Ok(dataTypeDtos);
    }

    // GET: data-types/5
    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<DataType>> GetDataType([FromRoute] Guid id)
    {
        DataType dataType = await _mediator.Send(new GetDataTypeQuery(id));
        DataTypeDto dataTypeDto = _mapper.Map<DataTypeDto>(dataType);

        return Ok(dataTypeDto);
    }

    // POST: data-types
    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<ActionResult> CreateDataType([FromBody] string type)
    {
        DataType dataType = await _mediator.Send(new CreateDataTypeCommand(type));
        DataTypeDto dataTypeDto = _mapper.Map<DataTypeDto>(dataType);

        return CreatedAtAction(nameof(GetDataType), new { dataTypeDto.Id }, dataTypeDto);
    }

    // DELETE: data-types/5
    [Authorize(Roles = "admin")]
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteDataType([FromRoute] Guid id)
    {
        await _mediator.Send(new DeleteDataTypeCommand(id));

        return NoContent();
    }

    // PUT: data-types/5
    [Authorize(Roles = "admin")]
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateDataType([FromRoute] Guid id, [FromBody] DataTypeDto dataTypeDto)
    {
        if (id != dataTypeDto.Id)
        {
            return BadRequest();
        }

        await _mediator.Send(new EditDataTypeCommand(dataTypeDto.Id, dataTypeDto.Value));

        return NoContent();
    }
}
