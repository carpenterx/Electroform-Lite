using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Documents.Commands.EditDocument;

public class EditDocumentCommandHandler : IRequestHandler<EditDocumentCommand, Document?>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditDocumentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Document?> Handle(EditDocumentCommand request, CancellationToken cancellationToken)
    {
        Document documentFromRequest = request.Document;
        Document? documentToEdit = await _unitOfWork.DocumentRepository.GetDocument(documentFromRequest.Id);
        if (documentToEdit == null)
        {
            return null;
        }
        documentToEdit.Name = documentFromRequest.Name;
        documentToEdit.Content = documentFromRequest.Content;
        _unitOfWork.DocumentRepository.Update(documentToEdit);
        await _unitOfWork.Save();

        return documentToEdit;
    }
}