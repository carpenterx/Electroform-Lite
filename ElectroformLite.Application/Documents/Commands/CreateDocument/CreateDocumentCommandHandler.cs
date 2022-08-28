using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Documents.Commands.CreateDocument;

public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, Document>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDocumentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Document> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
    {
        Document document = request.Document;

        _unitOfWork.DocumentRepository.Create(document);
        await _unitOfWork.Save();

        return document;
    }
}