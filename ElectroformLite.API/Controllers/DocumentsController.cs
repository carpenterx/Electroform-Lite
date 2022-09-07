using AutoMapper;
using ElectroformLite.API.Dto;
using ElectroformLite.Application.Documents.Commands.AddDataGroupToDocument;
using ElectroformLite.Application.Documents.Commands.CreateDocument;
using ElectroformLite.Application.Documents.Commands.DeleteDataGroupFromDocument;
using ElectroformLite.Application.Documents.Commands.DeleteDocument;
using ElectroformLite.Application.Documents.Commands.EditDocument;
using ElectroformLite.Application.Documents.Queries.GetDocument;
using ElectroformLite.Application.Documents.Queries.GetDocuments;
using ElectroformLite.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElectroformLite.API.Controllers;

[Route("documents")]
[ApiController]
public class DocumentsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public DocumentsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    // GET: documents
    [HttpGet]
    public async Task<ActionResult<List<Document>>> GetDocuments()
    {
        List<Document> documents = await _mediator.Send(new GetDocumentsQuery());
        List<DocumentGetPutDto> documentDtos = _mapper.Map<List<DocumentGetPutDto>>(documents);

        return Ok(documentDtos);
    }

    // GET: documents/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Document>> GetDocument([FromRoute] Guid id)
    {
        Document? document = await _mediator.Send(new GetDocumentQuery(id));

        if (document == null)
        {
            return NotFound();
        }

        DocumentGetPutDto documentDto = _mapper.Map<DocumentGetPutDto>(document);

        return Ok(documentDto);
    }

    // POST: documents
    [HttpPost]
    public async Task<IActionResult> CreateDocument([FromBody] DocumentPostDto documentDto)
    {
        Document? document = await _mediator.Send(new CreateDocumentCommand(documentDto.TemplateId, documentDto.DataGroupIds));

        if (document == null)
        {
            return NotFound();
        }

        DocumentGetPutDto dtoFromDocument = _mapper.Map<DocumentGetPutDto>(document);

        return CreatedAtAction(nameof(GetDocument), new { dtoFromDocument.Id }, dtoFromDocument);
    }

    // DELETE: documents/5
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteDocument([FromRoute] Guid id)
    {
        Document? document = await _mediator.Send(new DeleteDocumentCommand(id));

        if (document == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    // PUT: documents/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDocument([FromRoute] Guid id, [FromBody] DocumentGetPutDto documentDto)
    {
        if (id != documentDto.Id)
        {
            return BadRequest();
        }

        Document documentFromDto = _mapper.Map<Document>(documentDto);

        Document? editedDocument = await _mediator.Send(new EditDocumentCommand(documentFromDto));

        if (editedDocument == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    /*// POST: documents/5/data-groups/6
    [HttpPost]
    [Route("{documentId}/data-groups/{dataGroupId}")]
    public async Task<IActionResult> AddDataGroupToDocument([FromRoute] Guid documentId, [FromRoute] Guid dataGroupId)
    {
        Document? document = await _mediator.Send(new AddDataGroupToDocumentCommand(documentId, dataGroupId));

        if (document == null)
        {
            return NotFound();
        }

        DocumentGetPutDto dtoFromDocument = _mapper.Map<DocumentGetPutDto>(document);

        return CreatedAtAction(nameof(GetDocument), new { dtoFromDocument.Id }, dtoFromDocument);
    }*/

    /*// DELETE: documents/5/data-groups/6
    [HttpDelete]
    [Route("{documentId}/data-groups/{dataGroupId}")]
    public async Task<IActionResult> DeleteDataGroupFromDocument([FromRoute] Guid documentId, [FromRoute] Guid dataGroupId)
    {
        Document? document = await _mediator.Send(new DeleteDataGroupFromDocumentCommand(documentId, dataGroupId));

        if (document == null)
        {
            return NotFound();
        }

        return NoContent();
    }*/
}
