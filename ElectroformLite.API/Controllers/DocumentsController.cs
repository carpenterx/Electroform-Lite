using AutoMapper;
using ElectroformLite.API.Dto;
using ElectroformLite.Application.Documents.Commands.CreateDocument;
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
        List<DocumentGetDto> documentDtos = _mapper.Map<List<DocumentGetDto>>(documents);

        return Ok(documentDtos);
    }

    // GET: documents/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Document>> GetDocument([FromRoute] Guid id)
    {
        Document document = await _mediator.Send(new GetDocumentQuery(id));

        DocumentGetDto documentDto = _mapper.Map<DocumentGetDto>(document);

        return Ok(documentDto);
    }

    // POST: documents
    [HttpPost]
    public async Task<IActionResult> CreateDocument([FromBody] DocumentPostDto documentDto)
    {
        Document? document = await _mediator.Send(new CreateDocumentCommand(documentDto.DocumentName, documentDto.TemplateId, documentDto.AliasData));

        DocumentGetDto dtoFromDocument = _mapper.Map<DocumentGetDto>(document);

        return CreatedAtAction(nameof(GetDocument), new { dtoFromDocument.Id }, dtoFromDocument);
    }

    // DELETE: documents/5
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteDocument([FromRoute] Guid id)
    {
        await _mediator.Send(new DeleteDocumentCommand(id));

        return NoContent();
    }

    // PATCH: documents/5
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateDocumentName([FromRoute] Guid id, [FromBody] DocumentPatchDto documentDto)
    {
        if (id != documentDto.Id)
        {
            return BadRequest();
        }

        await _mediator.Send(new EditDocumentCommand(documentDto.Id, documentDto.Name));

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
