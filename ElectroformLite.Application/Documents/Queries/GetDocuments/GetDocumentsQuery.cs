using MediatR;
using ElectroformLite.Domain.Models;
using ElectroformLite.Application.Utils;

namespace ElectroformLite.Application.Documents.Queries.GetDocuments;

public class GetDocumentsQuery : IRequest<PaginatedResponse<List<Document>>>
{

}
