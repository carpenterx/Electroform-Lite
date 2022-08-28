using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Documents.Commands.AddDataGroupToDocument;

public class AddDataGroupToDocumentCommandHandler : IRequestHandler<AddDataGroupToDocumentCommand, Document?>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddDataGroupToDocumentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Document?> Handle(AddDataGroupToDocumentCommand request, CancellationToken cancellationToken)
    {
        Document? document = await _unitOfWork.DocumentRepository.GetDocument(request.DocumentId);
        DataGroup? dataGroup = await _unitOfWork.DataGroupRepository.GetDataGroup(request.DataGroupId);

        if (document is null || dataGroup is null)
        {
            return null;
        }

        document.DataGroups.Add(dataGroup);
        await _unitOfWork.Save();

        return document;
    }
}
