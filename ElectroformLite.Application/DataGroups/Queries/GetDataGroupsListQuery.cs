using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.DataGroups.Queries;

public class GetDataGroupsListQuery : IRequest<List<DataGroup>>
{

}
