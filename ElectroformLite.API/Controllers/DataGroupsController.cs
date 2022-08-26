using AutoMapper;
using ElectroformLite.API.Dto;
using ElectroformLite.Application.DataGroups.Commands.AddDataToDataGroup;
using ElectroformLite.Application.DataGroups.Commands.CreateDataGroup;
using ElectroformLite.Application.DataGroups.Commands.DeleteDataGroup;
using ElectroformLite.Application.DataGroups.Commands.EditDataGroup;
using ElectroformLite.Application.DataGroups.Queries.GetDataGroup;
using ElectroformLite.Application.DataGroups.Queries.GetDataGroups;
using ElectroformLite.Application.UserData.Commands.CreateData;
using ElectroformLite.Application.UserData.Commands.DeleteData;
using ElectroformLite.Application.UserData.Commands.EditData;
using ElectroformLite.Application.UserData.Queries.GetData;
using ElectroformLite.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace ElectroformLite.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DataGroupsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public DataGroupsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    // GET: DataGroups
    [HttpGet]
    public async Task<ActionResult<List<Data>>> GetDataGroups()
    {
        List<DataGroup> dataGroups = await _mediator.Send(new GetDataGroupsQuery());
        List<DataGroupGetPutDto> dataGroupDtos = _mapper.Map<List<DataGroupGetPutDto>>(dataGroups);

        return Ok(dataGroupDtos);
    }

    // GET: DataGroups/5
    [HttpGet("{id}")]
    public async Task<ActionResult<DataGroup>> GetDataGroup([FromRoute] Guid id)
    {
        DataGroup? dataGroup = await _mediator.Send(new GetDataGroupQuery(id));

        if (dataGroup == null)
        {
            return NotFound();
        }
        DataGroupGetPutDto dataGroupDto = _mapper.Map<DataGroupGetPutDto>(dataGroup);

        return Ok(dataGroupDto);
    }

    // POST: DataGroups
    [HttpPost]
    public async Task<IActionResult> CreateDataGroup([FromBody] DataGroupPostDto dataGroupDto)
    {
        DataGroup dataGroupFromDto = _mapper.Map<DataGroup>(dataGroupDto);
        DataGroup dataGroup = await _mediator.Send(new CreateDataGroupCommand(dataGroupFromDto));
        DataGroupGetPutDto dtoFromDataGroup = _mapper.Map<DataGroupGetPutDto>(dataGroup);

        return CreatedAtAction(nameof(GetDataGroup), new { dtoFromDataGroup.Id }, dtoFromDataGroup);
    }

    // DELETE: DataGroups/5
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

    // PUT: DataGroups/5
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

    // POST: DataGroups/5/Data/6
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
    }
}
