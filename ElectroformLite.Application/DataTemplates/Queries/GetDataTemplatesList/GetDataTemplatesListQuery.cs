using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.DataTemplates.Queries.GetDataTemplatesList;

public class GetDataTemplatesListQuery : IRequest<List<DataTemplate>>
{

}
