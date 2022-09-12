using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Documents.Queries.GetDocuments;

public class GetDocumentsQueryHandler : IRequestHandler<GetDocumentsQuery, List<Document>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDocumentsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Document>> Handle(GetDocumentsQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.DocumentRepository.GetDocuments();
    }
}