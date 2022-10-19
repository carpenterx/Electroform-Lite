using AutoMapper;
using ElectroformLite.Application.DataGroupTemplates.Commands.CreateDataGroupTemplate;
using ElectroformLite.Application.DataGroupTemplates.Commands.DeleteDataGroupTemplate;
using ElectroformLite.Application.DataGroupTemplates.Commands.EditDataGroupTemplate;
using ElectroformLite.Application.DataGroupTemplates.Queries.GetDataGroupTemplate;
using ElectroformLite.Application.DataGroupTemplates.Queries.GetDataGroupTemplates;
using ElectroformLite.Application.Dto;
using ElectroformLite.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectroformLite.API.Controllers;

[Route("data-group-templates")]
[ApiController]
public class DataGroupTemplatesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public DataGroupTemplatesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    // GET: data-group-templates
    [Authorize]
    [HttpGet]
    public async Task<ActionResult> GetDataGroupTemplates()
    {
        List<DataGroupTemplate> dataGroupTemplates = await _mediator.Send(new GetDataGroupTemplatesQuery());
        List<DataGroupTemplateGetDto> dataGroupTemplateDtos = _mapper.Map<List<DataGroupTemplateGetDto>>(dataGroupTemplates);

        return Ok(dataGroupTemplateDtos);
    }

    // GET: data-group-templates/5
    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult> GetDataGroupTemplate([FromRoute] Guid id)
    {
        DataGroupTemplate dataGroupTemplate = await _mediator.Send(new GetDataGroupTemplateQuery(id));

        DataGroupTemplateGetDto dataGroupTemplateDto = _mapper.Map<DataGroupTemplateGetDto>(dataGroupTemplate);

        return Ok(dataGroupTemplateDto);
    }

    // POST: data-group-templates
    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<ActionResult> CreateDataGroupTemplate([FromBody] DataGroupTemplatePostDto dataGroupTemplateDto)
    {
        DataGroupTemplate dataGroupTemplate = await _mediator.Send(new CreateDataGroupTemplateCommand(dataGroupTemplateDto.DataGroupTypeId, dataGroupTemplateDto.DataTemplateIds));

        DataGroupTemplateGetDto dtoFromDataGroupTemplate = _mapper.Map<DataGroupTemplateGetDto>(dataGroupTemplate);

        return CreatedAtAction(nameof(GetDataGroupTemplate), new { dtoFromDataGroupTemplate.Id }, dtoFromDataGroupTemplate);
    }

    // DELETE: data-group-templates/5
    [Authorize(Roles = "admin")]
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteDataGroupTemplate([FromRoute] Guid id)
    {
        await _mediator.Send(new DeleteDataGroupTemplateCommand(id));

        return NoContent();
    }

    // PUT: data-group-templates/5
    [Authorize(Roles = "admin")]
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateDataGroupTemplate([FromRoute] Guid id, [FromBody] DataGroupTemplatePutDto dataGroupTemplateDto)
    {
        if (id != dataGroupTemplateDto.Id)
        {
            return BadRequest();
        }

        await _mediator.Send(new EditDataGroupTemplateCommand(dataGroupTemplateDto.Id, dataGroupTemplateDto.DataTemplateIds));

        return NoContent();
    }
}
