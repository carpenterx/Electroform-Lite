using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.DataGroupTemplates.Queries;

public class GetDataGroupTemplatesListQuery : IRequest<List<DataGroupTemplate>>
{

}
