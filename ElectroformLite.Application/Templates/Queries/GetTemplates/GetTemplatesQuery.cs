using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Templates.Queries.GetTemplates;

public class GetTemplatesQuery : IRequest<List<Template>>
{

}
