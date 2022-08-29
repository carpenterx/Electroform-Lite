﻿using AutoMapper;
using ElectroformLite.API.Dto;
using ElectroformLite.Application.DataTypes.Commands.CreateDataType;
using ElectroformLite.Application.DataTypes.Commands.DeleteDataType;
using ElectroformLite.Application.DataTypes.Commands.EditDataType;
using ElectroformLite.Application.DataTypes.Queries.GetDataType;
using ElectroformLite.Application.DataTypes.Queries.GetDataTypes;
using ElectroformLite.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElectroformLite.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DataTypesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public DataTypesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    // GET: DataTypes
    [HttpGet]
    public async Task<ActionResult<List<DataType>>> GetDataTypes()
    {
        List<DataType> dataTypes = await _mediator.Send(new GetDataTypesQuery());
        List<DataTypeDto> dataTypeDtos = _mapper.Map<List<DataTypeDto>>(dataTypes);

        return Ok(dataTypeDtos);
    }

    // GET: DataTypes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<DataType>> GetDataType([FromRoute] Guid id)
    {
        DataType? dataType = await _mediator.Send(new GetDataTypeQuery(id));

        if (dataType == null)
        {
            return NotFound();
        }
        DataTypeDto dataTypeDto = _mapper.Map<DataTypeDto>(dataType);

        return Ok(dataTypeDto);
    }

    // POST: DataTypes
    [HttpPost]
    public async Task<IActionResult> CreateDataType([FromBody] string type)
    {
        DataType dataType = await _mediator.Send(new CreateDataTypeCommand(type));

        return CreatedAtAction(nameof(GetDataType), new { dataType.Id }, dataType);
    }

    // DELETE: DataTypes/5
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteDataType([FromRoute] Guid id)
    {
        DataType? dataType = await _mediator.Send(new DeleteDataTypeCommand(id));

        if (dataType == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    // PUT: DataTypes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDataType([FromRoute] Guid id, [FromBody] DataTypeDto dataTypeDto)
    {
        if (id != dataTypeDto.Id)
        {
            return BadRequest();
        }

        DataType dataTypeFromDto = _mapper.Map<DataType>(dataTypeDto);

        DataType? editedDataType = await _mediator.Send(new EditDataTypeCommand(dataTypeFromDto));

        if (editedDataType == null)
        {
            return NotFound();
        }

        return NoContent();
    }
}