using AutoMapper;
using ElectroformLite.Application.DataGroups.Commands.CreateDataGroup;
using ElectroformLite.Application.DataGroups.Commands.DeleteDataGroup;
using ElectroformLite.Application.DataGroups.Commands.EditDataGroup;
using ElectroformLite.Application.DataGroups.Queries.GetDataGroup;
using ElectroformLite.Application.DataGroups.Queries.GetDataGroups;
using ElectroformLite.Application.DataGroups.Queries.GetDataGroupsByType;
using ElectroformLite.Application.Dto;
using ElectroformLite.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectroformLite.API.Controllers;

[ApiController]
[Route("data-groups")]
public class DataGroupsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public DataGroupsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    // GET: data-groups
    [Authorize]
    [HttpGet]
    public async Task<ActionResult> GetDataGroups()
    {
        List<DataGroup> dataGroups = await _mediator.Send(new GetDataGroupsQuery());
        List<DataGroupGetDto> dataGroupDtos = _mapper.Map<List<DataGroupGetDto>>(dataGroups);

        return Ok(dataGroupDtos);
    }

    // GET: data-groups/5
    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult> GetDataGroup([FromRoute] Guid id)
    {
        DataGroup? dataGroup = await _mediator.Send(new GetDataGroupQuery(id));

        DataGroupGetDto dataGroupDto = _mapper.Map<DataGroupGetDto>(dataGroup);

        return Ok(dataGroupDto);
    }

    // GET: data-groups/type/5
    [Authorize]
    [HttpGet("type/{dataGroupTypeId}")]
    public async Task<ActionResult> GetDataGroupOfType([FromRoute] Guid dataGroupTypeId)
    {
        List<DataGroup> dataGroups = await _mediator.Send(new GetDataGroupsByTypeQuery(dataGroupTypeId));
        List<DataGroupGetPutDto> dataGroupDtos = _mapper.Map<List<DataGroupGetPutDto>>(dataGroups);

        return Ok(dataGroupDtos);
    }

    // POST: data-groups
    [Authorize]
    [HttpPost]
    public async Task<ActionResult> CreateDataGroup([FromBody] DataGroupPostDto dataGroupDto)
    {
        DataGroup? dataGroup = await _mediator.Send(new CreateDataGroupCommand(dataGroupDto.DataGroupTemplateId, dataGroupDto.Name, dataGroupDto.DataProperties));

        DataGroupGetPutDto dtoFromDataGroup = _mapper.Map<DataGroupGetPutDto>(dataGroup);

        return CreatedAtAction(nameof(GetDataGroup), new { dtoFromDataGroup.Id }, dtoFromDataGroup);
    }

    // DELETE: data-groups/5
    [Authorize]
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteDataGroup([FromRoute] Guid id)
    {
        await _mediator.Send(new DeleteDataGroupCommand(id));

        return NoContent();
    }

    // PUT: data-groups/5
    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateDataGroup([FromRoute] Guid id, [FromBody] DataGroupPutDto dataGroupDto)
    {
        if (id != dataGroupDto.Id)
        {
            return BadRequest();
        }

        await _mediator.Send(new EditDataGroupCommand(dataGroupDto));

        return NoContent();
    }

    /*// POST: data-groups/5/data/6
    [HttpPost]
    [Route("{dataGroupId}/data/{dataId}")]
    public async Task<ActionResult> AddDataToDataGroup([FromRoute] Guid dataGroupId, [FromRoute] Guid dataId)
    {
        DataGroup? dataGroup = await _mediator.Send(new AddDataToDataGroupCommand(dataGroupId, dataId));

        if (dataGroup == null)
        {
            return NotFound();
        }

        DataGroupGetPutDto dtoFromDataGroup = _mapper.Map<DataGroupGetPutDto>(dataGroup);

        return CreatedAtAction(nameof(GetDataGroup), new { dtoFromDataGroup.Id }, dtoFromDataGroup);
    }*/

    /*// DELETE: data-groups/5/data/6
    [HttpDelete]
    [Route("{dataGroupId}/data/{dataId}")]
    public async Task<ActionResult> DeleteDataFromDataGroup([FromRoute] Guid dataGroupId, [FromRoute] Guid dataId)
    {
        DataGroup? dataGroup = await _mediator.Send(new DeleteDataFromDataGroupCommand(dataGroupId, dataId));

        if (dataGroup == null)
        {
            return NotFound();
        }

        return NoContent();
    }*/
}
