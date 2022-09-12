using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Documents.Commands.CreateDocument;

public class CreateDocumentCommand : IRequest<Document?>
{
    public Guid TemplateId { get; set; }
    // alias template guid and data group guid
    public Dictionary<Guid, Guid> AliasData { get; set; }

    public CreateDocumentCommand(Guid templateId, Dictionary<Guid, Guid> aliasData)
    {
        TemplateId = templateId;
        AliasData = aliasData;
    }
}
