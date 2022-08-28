using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Documents.Commands.DeleteDataGroupFromDocument;

public class DeleteDataGroupFromDocumentCommandHandler : IRequestHandler<DeleteDataGroupFromDocumentCommand, Document?>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDataGroupFromDocumentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Document?> Handle(DeleteDataGroupFromDocumentCommand request, CancellationToken cancellationToken)
    {
        Document? document = await _unitOfWork.DocumentRepository.GetDocument(request.DocumentId);
        DataGroup? dataGroup = await _unitOfWork.DataGroupRepository.GetDataGroup(request.DataGroupId);

        if (document is null || dataGroup is null)
        {
            return null;
        }

        document.DataGroups.Remove(dataGroup);
        await _unitOfWork.Save();

        return document;
    }
}
