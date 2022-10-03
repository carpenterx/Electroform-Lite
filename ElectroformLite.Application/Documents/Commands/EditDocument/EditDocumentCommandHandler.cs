using ElectroformLite.Application.Exceptions;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Application.Utils;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Documents.Commands.EditDocument;

public class EditDocumentCommandHandler : IRequestHandler<EditDocumentCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditDocumentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(EditDocumentCommand request, CancellationToken cancellationToken)
    {
        Document? documentToEdit = await _unitOfWork.DocumentRepository.GetDocument(request.DocumentId);
        if (documentToEdit == null)
        {
            HttpResponseMessage response = HttpUtilities.HttpResponseMessageBuilder("Document Not Found");
            throw new NotFoundHttpResponseException(response);
        }
        documentToEdit.Name = request.NewDocumentName;
        _unitOfWork.DocumentRepository.Update(documentToEdit);
        await _unitOfWork.Save();

        return Unit.Value;
    }
}