using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Documents.Commands.CreateDocument;

public class CreateDocumentCommand : IRequest<Document?>
{

    public string DocumentName { get; set; }
    public Guid TemplateId { get; set; }
    // alias template guid and data group guid
    public Dictionary<Guid, Guid> AliasData { get; set; }

    public CreateDocumentCommand(string documentName, Guid templateId, Dictionary<Guid, Guid> aliasData)
    {
        DocumentName = documentName;
        TemplateId = templateId;
        AliasData = aliasData;
    }
}
