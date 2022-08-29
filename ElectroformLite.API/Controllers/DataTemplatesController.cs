﻿using AutoMapper;
using ElectroformLite.API.Dto;
using ElectroformLite.Application.DataTemplates.Commands.CreateDataTemplate;
using ElectroformLite.Application.DataTemplates.Commands.DeleteDataTemplate;
using ElectroformLite.Application.DataTemplates.Commands.EditDataTemplate;
using ElectroformLite.Application.DataTemplates.Queries.GetDataTemplate;
using ElectroformLite.Application.DataTemplates.Queries.GetDataTemplates;
using ElectroformLite.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElectroformLite.API.Controllers;

[Route("[controller]")]
[ApiController]
public class DataTemplatesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public DataTemplatesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    // GET: DataTemplates
    [HttpGet]
    public async Task<ActionResult<List<DataTemplate>>> GetDataTemplates()
    {
        List<DataTemplate> dataTemplates = await _mediator.Send(new GetDataTemplatesQuery());
        List<DataTemplateGetPutDto> dataTemplateDtos = _mapper.Map<List<DataTemplateGetPutDto>>(dataTemplates);

        return Ok(dataTemplateDtos);
    }

    // GET: DataTemplates/5
    [HttpGet("{id}")]
    public async Task<ActionResult<DataTemplate>> GetDataTemplate([FromRoute] Guid id)
    {
        DataTemplate? dataTemplate = await _mediator.Send(new GetDataTemplateQuery(id));

        if (dataTemplate == null)
        {
            return NotFound();
        }
        DataTemplateGetPutDto dataTemplateDto = _mapper.Map<DataTemplateGetPutDto>(dataTemplate);

        return Ok(dataTemplateDto);
    }

    // POST: DataTemplates
    [HttpPost]
    public async Task<IActionResult> CreateDataTemplate([FromBody] DataTemplatePostDto dataTemplateDto)
    {
        DataTemplate dataTemplateFromDto = _mapper.Map<DataTemplate>(dataTemplateDto);
        DataTemplate dataTemplate = await _mediator.Send(new CreateDataTemplateCommand(dataTemplateFromDto));
        DataTemplateGetPutDto dtoFromDataTemplate = _mapper.Map<DataTemplateGetPutDto>(dataTemplate);

        return CreatedAtAction(nameof(GetDataTemplate), new { dtoFromDataTemplate.Id }, dtoFromDataTemplate);
    }

    // DELETE: DataTemplates/5
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteDataTemplate([FromRoute] Guid id)
    {
        DataTemplate? dataTemplate = await _mediator.Send(new DeleteDataTemplateCommand(id));

        if (dataTemplate == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    // PUT: DataTemplates/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDataTemplate([FromRoute] Guid id, [FromBody] DataTemplateGetPutDto dataTemplateDto)
    {
        if (id != dataTemplateDto.Id)
        {
            return BadRequest();
        }

        DataTemplate dataTemplateFromDto = _mapper.Map<DataTemplate>(dataTemplateDto);

        DataTemplate? editedDataTemplate = await _mediator.Send(new EditDataTemplateCommand(dataTemplateFromDto));

        if (editedDataTemplate == null)
        {
            return NotFound();
        }

        return NoContent();
    }
}