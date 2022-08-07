using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.DataGroupTemplates.Queries.GetDataGroupTemplatesList;

public class GetDataGroupTemplatesListQuery : IRequest<List<DataGroupTemplate>>
{

}
