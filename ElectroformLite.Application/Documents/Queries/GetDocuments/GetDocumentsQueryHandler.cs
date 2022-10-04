using ElectroformLite.Application.Interfaces;
using ElectroformLite.Application.Utils;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Documents.Queries.GetDocuments;

public class GetDocumentsQueryHandler : IRequestHandler<GetDocumentsQuery, PaginatedResponse<List<Document>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDocumentsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PaginatedResponse<List<Document>>> Handle(GetDocumentsQuery request, CancellationToken cancellationToken)
    {
        int pageSize = 4;
        int pageNumber = 1;

        List<Document> documents = await _unitOfWork.DocumentRepository.GetDocuments(pageNumber, pageSize);
        return new PaginatedResponse<List<Document>>(documents, pageNumber, pageSize);
    }
}