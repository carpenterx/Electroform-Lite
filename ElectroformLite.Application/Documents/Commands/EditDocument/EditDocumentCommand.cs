using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Documents.Commands.EditDocument;

public class EditDocumentCommand : IRequest
{
    public Document Document { get; set; }

    public EditDocumentCommand(Document document)
    {
        Document = document;
    }
}