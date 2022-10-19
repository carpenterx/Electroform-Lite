using AutoMapper;
using ElectroformLite.Application.DataTemplates.Commands.CreateDataTemplate;
using ElectroformLite.Application.DataTemplates.Commands.DeleteDataTemplate;
using ElectroformLite.Application.DataTemplates.Commands.EditDataTemplate;
using ElectroformLite.Application.DataTemplates.Queries.GetDataTemplate;
using ElectroformLite.Application.DataTemplates.Queries.GetDataTemplates;
using ElectroformLite.Application.Dto;
using ElectroformLite.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ElectroformLite.API.Controllers;

[Route("data-templates")]
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

    // GET: data-templates
    [Authorize]
    [HttpGet]
    public async Task<ActionResult> GetDataTemplates()
    {
        List<DataTemplate> dataTemplates = await _mediator.Send(new GetDataTemplatesQuery());
        List<DataTemplateGetDto> dataTemplateDtos = _mapper.Map<List<DataTemplateGetDto>>(dataTemplates);

        return Ok(dataTemplateDtos);
    }

    // GET: data-templates/5
    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult> GetDataTemplate([FromRoute] Guid id)
    {
        DataTemplate dataTemplate = await _mediator.Send(new GetDataTemplateQuery(id));
        DataTemplateGetPutDto dataTemplateDto = _mapper.Map<DataTemplateGetPutDto>(dataTemplate);

        return Ok(dataTemplateDto);
    }

    // POST: data-templates
    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<ActionResult> CreateDataTemplate([FromBody] DataTemplatePostDto dataTemplateDto)
    {
        DataTemplate dataTemplate = await _mediator.Send(new CreateDataTemplateCommand(dataTemplateDto.DataTypeId, dataTemplateDto.Placeholder));
        DataTemplateGetDto dtoFromDataTemplate = _mapper.Map<DataTemplateGetDto>(dataTemplate);

        return CreatedAtAction(nameof(GetDataTemplate), new { dtoFromDataTemplate.Id }, dtoFromDataTemplate);
    }

    // DELETE: data-templates/5
    [Authorize(Roles = "admin")]
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteDataTemplate([FromRoute] Guid id)
    {
        await _mediator.Send(new DeleteDataTemplateCommand(id));

        return NoContent();
    }

    // PUT: data-templates/5
    [Authorize(Roles = "admin")]
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateDataTemplate([FromRoute] Guid id, [FromBody] DataTemplateGetPutDto dataTemplateDto)
    {
        if (id != dataTemplateDto.Id)
        {
            return BadRequest();
        }

        await _mediator.Send(new EditDataTemplateCommand(dataTemplateDto.Id, dataTemplateDto.Placeholder));

        return NoContent();
    }
}
