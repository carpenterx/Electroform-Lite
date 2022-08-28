using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Documents.Commands.AddDataGroupToDocument;

public class AddDataGroupToDocumentCommand : IRequest<Document?>
{
    public Guid DocumentId { get; set; }
    public Guid DataGroupId { get; set; }

    public AddDataGroupToDocumentCommand(Guid documentId, Guid dataGroupId)
    {
        DocumentId = documentId;
        DataGroupId = dataGroupId;
    }
}
