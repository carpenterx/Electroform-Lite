using AutoMapper;
using ElectroformLite.Application.Dto;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Application.Utils;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Documents.Queries.GetDocuments;

public class GetDocumentsQueryHandler : IRequestHandler<GetDocumentsQuery, PaginatedResponse<List<DocumentGetDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUriService _uriService;
    private readonly IMapper _mapper;

    public GetDocumentsQueryHandler(IUnitOfWork unitOfWork, IUriService uriService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _uriService = uriService;
        _mapper = mapper;
    }

    public async Task<PaginatedResponse<List<DocumentGetDto>>> Handle(GetDocumentsQuery request, CancellationToken cancellationToken)
    {
        int pageNumber = -1;
        int pageSize = 4;
        int totalCount = await _unitOfWork.DocumentRepository.GetCount();

        PaginationValidator pagination = new(pageNumber, pageSize, totalCount);

        List<Document> documents = await _unitOfWork.DocumentRepository.GetDocuments(pagination.PageNumber, pagination.PageSize);
        List<DocumentGetDto> documentDtos = _mapper.Map<List<DocumentGetDto>>(documents);

        var paginatedResponse = PaginationHelper.CreatePaginatedReponse<List<DocumentGetDto>>(documentDtos, pagination.PageNumber, pagination.PageSize, totalCount, _uriService, request.Route);
        //return new PaginatedResponse<List<DocumentGetDto>>(documentDtos, pagination.PageNumber, pagination.PageSize);
        return paginatedResponse;
    }
}