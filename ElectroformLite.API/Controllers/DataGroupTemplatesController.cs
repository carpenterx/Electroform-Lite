using AutoMapper;
using ElectroformLite.API.Dto;
using ElectroformLite.Application.DataGroupTemplates.Commands.CreateDataGroupTemplate;
using ElectroformLite.Application.DataGroupTemplates.Commands.DeleteDataGroupTemplate;
using ElectroformLite.Application.DataGroupTemplates.Commands.EditDataGroupTemplate;
using ElectroformLite.Application.DataGroupTemplates.Queries.GetDataGroupTemplate;
using ElectroformLite.Application.DataGroupTemplates.Queries.GetDataGroupTemplates;
using ElectroformLite.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElectroformLite.API.Controllers;

[Route("[controller]")]
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

    // GET: DataGroupTemplates
    [HttpGet]
    public async Task<ActionResult<List<DataGroupTemplate>>> GetDataGroupTemplates()
    {
        List<DataGroupTemplate> dataGroupTemplates = await _mediator.Send(new GetDataGroupTemplatesQuery());
        List<DataGroupTemplateGetPutDto> dataGroupTemplateDtos = _mapper.Map<List<DataGroupTemplateGetPutDto>>(dataGroupTemplates);

        return Ok(dataGroupTemplateDtos);
    }

    // GET: DataGroupTemplates/5
    [HttpGet("{id}")]
    public async Task<ActionResult<DataGroupTemplate>> GetDataGroupTemplate([FromRoute] Guid id)
    {
        DataGroupTemplate? dataGroupTemplate = await _mediator.Send(new GetDataGroupTemplateQuery(id));

        if (dataGroupTemplate == null)
        {
            return NotFound();
        }
        DataGroupTemplateGetPutDto dataGroupTemplateDto = _mapper.Map<DataGroupTemplateGetPutDto>(dataGroupTemplate);

        return Ok(dataGroupTemplateDto);
    }

    // POST: DataGroupTemplates
    [HttpPost]
    public async Task<IActionResult> CreateDataGroupTemplate([FromBody] DataGroupTemplatePostDto dataGroupTemplateDto)
    {
        DataGroupTemplate dataGroupTemplateFromDto = _mapper.Map<DataGroupTemplate>(dataGroupTemplateDto);
        DataGroupTemplate dataGroupTemplate = await _mediator.Send(new CreateDataGroupTemplateCommand(dataGroupTemplateFromDto));
        DataGroupTemplateGetPutDto dtoFromDataGroupTemplate = _mapper.Map<DataGroupTemplateGetPutDto>(dataGroupTemplate);

        return CreatedAtAction(nameof(GetDataGroupTemplate), new { dtoFromDataGroupTemplate.Id }, dtoFromDataGroupTemplate);
    }

    // DELETE: DataGroupTemplates/5
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteDataGroupTemplate([FromRoute] Guid id)
    {
        DataGroupTemplate? dataGroupTemplate = await _mediator.Send(new DeleteDataGroupTemplateCommand(id));

        if (dataGroupTemplate == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    // PUT: DataGroupTemplates/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDataGroupTemplate([FromRoute] Guid id, [FromBody] DataGroupTemplateGetPutDto dataGroupTemplateDto)
    {
        if (id != dataGroupTemplateDto.Id)
        {
            return BadRequest();
        }

        DataGroupTemplate dataGroupTemplateFromDto = _mapper.Map<DataGroupTemplate>(dataGroupTemplateDto);

        DataGroupTemplate? editedDataGroupTemplate = await _mediator.Send(new EditDataGroupTemplateCommand(dataGroupTemplateFromDto));

        if (editedDataGroupTemplate == null)
        {
            return NotFound();
        }

        return NoContent();
    }
}
