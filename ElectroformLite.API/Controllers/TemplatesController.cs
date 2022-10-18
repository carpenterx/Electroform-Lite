using AutoMapper;
using ElectroformLite.Application.Dto;
using ElectroformLite.Application.Templates.Commands.CreateTemplate;
using ElectroformLite.Application.Templates.Commands.DeleteTemplate;
using ElectroformLite.Application.Templates.Commands.EditTemplate;
using ElectroformLite.Application.Templates.Queries.GetTemplate;
using ElectroformLite.Application.Templates.Queries.GetTemplates;
using ElectroformLite.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElectroformLite.API.Controllers;

[Route("templates")]
[ApiController]
public class TemplatesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public TemplatesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    // GET: templates
    [HttpGet]
    public async Task<ActionResult> GetTemplates()
    {
        List<Template> templates = await _mediator.Send(new GetTemplatesQuery());
        List<TemplateGetPutDto> templateDtos = _mapper.Map<List<TemplateGetPutDto>>(templates);

        return Ok(templateDtos);
    }

    // GET: templates/5
    [HttpGet("{id}")]
    public async Task<ActionResult> GetTemplate([FromRoute] Guid id)
    {
        Template template = await _mediator.Send(new GetTemplateQuery(id));

        TemplateGetDto templateDto = _mapper.Map<TemplateGetDto>(template);

        return Ok(templateDto);
    }

    // POST: templates
    [HttpPost]
    public async Task<ActionResult> CreateTemplate([FromBody] TemplatePostDto templateDto)
    {
        Template template = await _mediator.Send(new CreateTemplateCommand(templateDto.Name, templateDto.Content, templateDto.AliasTemplateData));

        TemplateGetPutDto dtoFromTemplate = _mapper.Map<TemplateGetPutDto>(template);

        return CreatedAtAction(nameof(GetTemplate), new { dtoFromTemplate.Id }, dtoFromTemplate);
    }

    // DELETE: templates/5
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteTemplate([FromRoute] Guid id)
    {
        await _mediator.Send(new DeleteTemplateCommand(id));

        return NoContent();
    }

    // PUT: templates/5
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateTemplate([FromRoute] Guid id, [FromBody] TemplatePutDto templateDto)
    {
        if (id != templateDto.Id)
        {
            return BadRequest();
        }

        await _mediator.Send(new EditTemplateCommand(templateDto.Id, templateDto.Name, templateDto.Content, templateDto.AliasTemplatesData));

        return NoContent();
    }
}
