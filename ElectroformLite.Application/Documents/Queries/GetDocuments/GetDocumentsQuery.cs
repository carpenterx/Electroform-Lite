using MediatR;
using ElectroformLite.Application.Utils;
using ElectroformLite.Application.Dto;

namespace ElectroformLite.Application.Documents.Queries.GetDocuments;

public class GetDocumentsQuery : IRequest<PaginatedResponse<List<DocumentGetDto>>>
{
    public string Route { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public GetDocumentsQuery(string route, int pageNumber, int pageSize)
    {
        Route = route;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
