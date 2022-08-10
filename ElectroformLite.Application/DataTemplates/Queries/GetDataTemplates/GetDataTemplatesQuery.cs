using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.DataTemplates.Queries.GetDataTemplates;

public class GetDataTemplatesQuery : IRequest<List<DataTemplate>>
{

}
