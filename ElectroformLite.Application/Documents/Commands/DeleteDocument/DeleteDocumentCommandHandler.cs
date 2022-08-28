using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Documents.Commands.DeleteDocument;

public class DeleteDocumentCommandHandler : IRequestHandler<DeleteDocumentCommand, Document?>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDocumentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Document?> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
    {
        Document? document = await _unitOfWork.DocumentRepository.GetDocument(request.DocumentId);
        if (document == null)
        {
            return null;
        }

        _unitOfWork.DocumentRepository.Delete(document);
        await _unitOfWork.Save();

        return document;
    }
}