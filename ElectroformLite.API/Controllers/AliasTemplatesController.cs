using AutoMapper;
using ElectroformLite.API.Dto;
using ElectroformLite.Application.AliasTemplates.Queries.GetAliasTemplate;
using ElectroformLite.Application.AliasTemplates.Queries.GetAliasTemplates;
using ElectroformLite.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElectroformLite.API.Controllers;

[Route("alias-templates")]
[ApiController]
public class AliasTemplatesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AliasTemplatesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    // GET: alias-templates
    [HttpGet]
    public async Task<ActionResult<List<AliasTemplate>>> GetAliasTemplates()
    {
        List<AliasTemplate> aliasTemplates = await _mediator.Send(new GetAliasTemplatesQuery());
        List<AliasTemplateGetDto> aliasTemplatesDtos = _mapper.Map<List<AliasTemplateGetDto>>(aliasTemplates);

        return Ok(aliasTemplatesDtos);
    }

    // GET: alias-templates/5
    [HttpGet("{id}")]
    public async Task<ActionResult<AliasTemplate>> GetAliasTemplate([FromRoute] Guid id)
    {
        AliasTemplate? aliasTemplate = await _mediator.Send(new GetAliasTemplateQuery(id));

        if (aliasTemplate == null)
        {
            return NotFound();
        }

        AliasTemplateGetDto aliasTemplateDto = _mapper.Map<AliasTemplateGetDto>(aliasTemplate);

        return Ok(aliasTemplateDto);
    }
}
