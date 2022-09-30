using AutoMapper;
using ElectroformLite.API.Dto;
using ElectroformLite.Application.DataGroups.Commands.CreateDataGroup;
using ElectroformLite.Application.DataGroups.Commands.DeleteDataGroup;
using ElectroformLite.Application.DataGroups.Commands.EditDataGroup;
using ElectroformLite.Application.DataGroups.Queries.GetDataGroup;
using ElectroformLite.Application.DataGroups.Queries.GetDataGroups;
using ElectroformLite.Application.DataGroups.Queries.GetDataGroupsByType;
using ElectroformLite.Domain.Models;
using MediatR;
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
    [HttpGet]
    public async Task<ActionResult<List<DataGroup>>> GetDataGroups()
    {
        List<DataGroup> dataGroups = await _mediator.Send(new GetDataGroupsQuery());
        List<DataGroupGetDto> dataGroupDtos = _mapper.Map<List<DataGroupGetDto>>(dataGroups);

        return Ok(dataGroupDtos);
    }

    // GET: data-groups/5
    [HttpGet("{id}")]
    public async Task<ActionResult<DataGroup>> GetDataGroup([FromRoute] Guid id)
    {
        DataGroup? dataGroup = await _mediator.Send(new GetDataGroupQuery(id));

        if (dataGroup == null)
        {
            return NotFound();
        }
        DataGroupGetDto dataGroupDto = _mapper.Map<DataGroupGetDto>(dataGroup);

        return Ok(dataGroupDto);
    }

    // GET: data-groups/type/5
    [HttpGet("type/{dataGroupTypeId}")]
    public async Task<ActionResult<DataGroup>> GetDataGroupOfType([FromRoute] Guid dataGroupTypeId)
    {
        List<DataGroup> dataGroups = await _mediator.Send(new GetDataGroupsByTypeQuery(dataGroupTypeId));
        List<DataGroupGetPutDto> dataGroupDtos = _mapper.Map<List<DataGroupGetPutDto>>(dataGroups);

        return Ok(dataGroupDtos);
    }

    // POST: data-groups
    [HttpPost]
    public async Task<IActionResult> CreateDataGroup([FromBody] DataGroupPostDto dataGroupDto)
    {
        DataGroup? dataGroup = await _mediator.Send(new CreateDataGroupCommand(dataGroupDto.DataGroupTemplateId, dataGroupDto.Name, dataGroupDto.DataProperties));

        if (dataGroup == null)
        {
            return NotFound();
        }

        DataGroupGetPutDto dtoFromDataGroup = _mapper.Map<DataGroupGetPutDto>(dataGroup);

        return CreatedAtAction(nameof(GetDataGroup), new { dtoFromDataGroup.Id }, dtoFromDataGroup);
    }

    // DELETE: data-groups/5
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteDataGroup([FromRoute] Guid id)
    {
        DataGroup? dataGroup = await _mediator.Send(new DeleteDataGroupCommand(id));

        if (dataGroup == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    // PUT: data-groups/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDataGroup([FromRoute] Guid id, [FromBody] DataGroupGetPutDto dataGroupDto)
    {
        if (id != dataGroupDto.Id)
        {
            return BadRequest();
        }

        DataGroup dataGroupFromDto = _mapper.Map<DataGroup>(dataGroupDto);

        DataGroup? editedDataGroup = await _mediator.Send(new EditDataGroupCommand(dataGroupFromDto));

        if (editedDataGroup == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    /*// POST: data-groups/5/data/6
    [HttpPost]
    [Route("{dataGroupId}/data/{dataId}")]
    public async Task<IActionResult> AddDataToDataGroup([FromRoute] Guid dataGroupId, [FromRoute] Guid dataId)
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
    public async Task<IActionResult> DeleteDataFromDataGroup([FromRoute] Guid dataGroupId, [FromRoute] Guid dataId)
    {
        DataGroup? dataGroup = await _mediator.Send(new DeleteDataFromDataGroupCommand(dataGroupId, dataId));

        if (dataGroup == null)
        {
            return NotFound();
        }

        return NoContent();
    }*/
}
