using MediatR;
using ElectroformLite.Application.Utils;
using ElectroformLite.Application.Dto;

namespace ElectroformLite.Application.Documents.Queries.GetDocuments;

public class GetDocumentsQuery : IRequest<PaginatedResponse<List<DocumentGetDto>>>
{
    public string Route { get; set; }

    public GetDocumentsQuery(string route)
    {
        Route = route;
    }
}
