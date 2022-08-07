using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Documents.Queries.GetDocuments;

public class GetDocumentsQuery : IRequest<List<Document>>
{

}
