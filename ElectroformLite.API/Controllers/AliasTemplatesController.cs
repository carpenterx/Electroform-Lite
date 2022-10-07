using AutoMapper;
using ElectroformLite.Application.AliasTemplates.Queries.GetAliasTemplate;
using ElectroformLite.Application.AliasTemplates.Queries.GetAliasTemplateId;
using ElectroformLite.Application.AliasTemplates.Queries.GetAliasTemplates;
using ElectroformLite.Application.Dto;
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
    public async Task<ActionResult> GetAliasTemplates()
    {
        List<AliasTemplate> aliasTemplates = await _mediator.Send(new GetAliasTemplatesQuery());
        List<AliasTemplateGetDto> aliasTemplatesDtos = _mapper.Map<List<AliasTemplateGetDto>>(aliasTemplates);

        return Ok(aliasTemplatesDtos);
    }

    // GET: alias-templates/5
    [HttpGet("{id}")]
    public async Task<ActionResult> GetAliasTemplate([FromRoute] Guid id)
    {
        AliasTemplate? aliasTemplate = await _mediator.Send(new GetAliasTemplateQuery(id));

        AliasTemplateGetDto aliasTemplateDto = _mapper.Map<AliasTemplateGetDto>(aliasTemplate);

        return Ok(aliasTemplateDto);
    }

    // GET: alias-templates/get-id/5
    [HttpGet("get-id/{dataGroupTemplateId}")]
    public async Task<ActionResult> GetAliasTemplateId([FromRoute] Guid dataGroupTemplateId)
    {
        Guid aliasTemplateId = await _mediator.Send(new GetAliasTemplateIdQuery(dataGroupTemplateId));

        return Ok(aliasTemplateId);
    }
}
