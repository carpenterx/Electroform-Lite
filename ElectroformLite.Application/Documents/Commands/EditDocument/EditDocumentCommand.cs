using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Documents.Commands.EditDocument;

public class EditDocumentCommand : IRequest
{
    public Guid DocumentId { get; set; }

    public string NewDocumentName { get; set; }

    public EditDocumentCommand(Guid documentId, string newDocumentName)
    {
        DocumentId = documentId;
        NewDocumentName = newDocumentName;
    }
}