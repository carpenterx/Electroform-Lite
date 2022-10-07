using AutoMapper;
using ElectroformLite.Application.Dto;
using ElectroformLite.Application.UserData.Commands.CreateData;
using ElectroformLite.Application.UserData.Commands.DeleteData;
using ElectroformLite.Application.UserData.Commands.EditData;
using ElectroformLite.Application.UserData.Queries.GetData;
using ElectroformLite.Application.UserData.Queries.GetDataList;
using ElectroformLite.Domain.Models;
using MediatR;
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
    [HttpGet]
    public async Task<ActionResult> GetData()
    {
        List<Data> data = await _mediator.Send(new GetDataListQuery());
        List<DataGetPutDto> dataDtos = _mapper.Map<List<DataGetPutDto>>(data);

        return Ok(dataDtos);
    }

    // GET: data/5
    [HttpGet("{id}")]
    public async Task<ActionResult> GetData([FromRoute] Guid id)
    {
        Data? data = await _mediator.Send(new GetDataQuery(id));

        if (data == null)
        {
            return NotFound();
        }
        DataGetPutDto dataDto = _mapper.Map<DataGetPutDto>(data);

        return Ok(dataDto);
    }

    // POST: data
    [HttpPost]
    public async Task<ActionResult> CreateData([FromBody] DataPostDto dataDto)
    {
        //Data dataFromDto = _mapper.Map<Data>(dataDto);
        Data? data = await _mediator.Send(new CreateDataCommand(dataDto.DataTemplateId, dataDto.Value));

        if (data == null)
        {
            return NotFound();
        }

        DataGetPutDto dtoFromData = _mapper.Map<DataGetPutDto>(data);

        return CreatedAtAction(nameof(GetData), new { dtoFromData.Id }, dtoFromData);
    }

    // DELETE: data/5
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteData([FromRoute] Guid id)
    {
        Data? data = await _mediator.Send(new DeleteDataCommand(id));

        if (data == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    // PUT: data/5
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateData([FromRoute] Guid id, [FromBody] DataGetPutDto dataDto)
    {
        if (id != dataDto.Id)
        {
            return BadRequest();
        }

        Data dataFromDto = _mapper.Map<Data>(dataDto);

        Data? editedData = await _mediator.Send(new EditDataCommand(dataFromDto));

        if (editedData == null)
        {
            return NotFound();
        }

        return NoContent();
    }
}
