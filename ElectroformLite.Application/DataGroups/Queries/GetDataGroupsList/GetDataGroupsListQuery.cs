using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.DataGroups.Queries.GetDataGroupsList;

public class GetDataGroupsListQuery : IRequest<List<DataGroup>>
{

}
