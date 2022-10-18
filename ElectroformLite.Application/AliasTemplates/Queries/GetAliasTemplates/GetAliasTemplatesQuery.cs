using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.AliasTemplates.Queries.GetAliasTemplates;

public class GetAliasTemplatesQuery : IRequest<List<AliasTemplate>>
{

}
