using AutoMapper;
using ElectroformLite.Application.Dto;
using ElectroformLite.Application.UserData.Commands.CreateData;
using ElectroformLite.Application.UserData.Commands.DeleteData;
using ElectroformLite.Application.UserData.Commands.EditData;
using ElectroformLite.Application.UserData.Queries.GetData;
using ElectroformLite.Application.UserData.Queries.GetDataList;
using ElectroformLite.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectroformLite.API.Controllers;

[ApiController]
[Route("data")]
public class DataController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public DataController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    // GET: data
    [Authorize]
    [HttpGet]
    public async Task<ActionResult> GetData()
    {
        List<Data> data = await _mediator.Send(new GetDataListQuery());
        List<DataGetPutDto> dataDtos = _mapper.Map<List<DataGetPutDto>>(data);

        return Ok(dataDtos);
    }

    // GET: data/5
    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult> GetData([FromRoute] Guid id)
    {
        Data data = await _mediator.Send(new GetDataQuery(id));

        DataGetPutDto dataDto = _mapper.Map<DataGetPutDto>(data);

        return Ok(dataDto);
    }

    // POST: data
    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<ActionResult> CreateData([FromBody] DataPostDto dataDto)
    {
        Data data = await _mediator.Send(new CreateDataCommand(dataDto.DataTemplateId, dataDto.Value));

        DataGetPutDto dtoFromData = _mapper.Map<DataGetPutDto>(data);

        return CreatedAtAction(nameof(GetData), new { dtoFromData.Id }, dtoFromData);
    }

    // DELETE: data/5
    [Authorize(Roles = "admin")]
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteData([FromRoute] Guid id)
    {
        await _mediator.Send(new DeleteDataCommand(id));

        return NoContent();
    }

    // PUT: data/5
    [Authorize(Roles = "admin")]
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateData([FromRoute] Guid id, [FromBody] DataGetPutDto dataDto)
    {
        if (id != dataDto.Id)
        {
            return BadRequest();
        }

        Data dataFromDto = _mapper.Map<Data>(dataDto);

        await _mediator.Send(new EditDataCommand(dataFromDto));

        return NoContent();
    }
}
