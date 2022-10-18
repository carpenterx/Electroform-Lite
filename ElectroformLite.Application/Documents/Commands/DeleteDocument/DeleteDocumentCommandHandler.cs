using ElectroformLite.Application.Exceptions;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Application.Utils;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Documents.Commands.DeleteDocument;

public class DeleteDocumentCommandHandler : IRequestHandler<DeleteDocumentCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDocumentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
    {
        Document? document = await _unitOfWork.DocumentRepository.GetDocument(request.DocumentId);
        if (document == null)
        {
            HttpResponseMessage response = HttpUtilities.HttpResponseMessageBuilder("Document Not Found");
            throw new NotFoundHttpResponseException(response);
        }

        _unitOfWork.DocumentRepository.Delete(document);
        await _unitOfWork.Save();

        return Unit.Value;
    }
}