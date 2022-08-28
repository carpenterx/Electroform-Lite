using AutoMapper;
using ElectroformLite.API.Dto;
using ElectroformLite.Application.Templates.Commands.CreateTemplate;
using ElectroformLite.Application.Templates.Commands.DeleteTemplate;
using ElectroformLite.Application.Templates.Commands.EditTemplate;
using ElectroformLite.Application.Templates.Queries.GetTemplate;
using ElectroformLite.Application.Templates.Queries.GetTemplates;
using ElectroformLite.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElectroformLite.API.Controllers;

[Route("[controller]")]
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

    // GET: Templates
    [HttpGet]
    public async Task<ActionResult<List<Template>>> GetTemplates()
    {
        List<Template> templates = await _mediator.Send(new GetTemplatesQuery());
        List<TemplateGetPutDto> templateDtos = _mapper.Map<List<TemplateGetPutDto>>(templates);

        return Ok(templateDtos);
    }

    // GET: Templates/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Template>> GetTemplate([FromRoute] Guid id)
    {
        Template? template = await _mediator.Send(new GetTemplateQuery(id));

        if (template == null)
        {
            return NotFound();
        }
        TemplateGetPutDto templateDto = _mapper.Map<TemplateGetPutDto>(template);

        return Ok(templateDto);
    }

    // POST: Templates
    [HttpPost]
    public async Task<IActionResult> CreateTemplate([FromBody] TemplatePostDto templateDto)
    {
        Template templateFromDto = _mapper.Map<Template>(templateDto);
        Template template = await _mediator.Send(new CreateTemplateCommand(templateFromDto));
        TemplateGetPutDto dtoFromTemplate = _mapper.Map<TemplateGetPutDto>(template);

        return CreatedAtAction(nameof(GetTemplate), new { dtoFromTemplate.Id }, dtoFromTemplate);
    }

    // DELETE: Templates/5
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteTemplate([FromRoute] Guid id)
    {
        Template? template = await _mediator.Send(new DeleteTemplateCommand(id));

        if (template == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    // PUT: Templates/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTemplate([FromRoute] Guid id, [FromBody] TemplateGetPutDto templateDto)
    {
        if (id != templateDto.Id)
        {
            return BadRequest();
        }

        Template templateFromDto = _mapper.Map<Template>(templateDto);

        Template? editedTemplate = await _mediator.Send(new EditTemplateCommand(templateFromDto));

        if (editedTemplate == null)
        {
            return NotFound();
        }

        return NoContent();
    }
}
