using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.DataGroups.Queries.GetDataGroups;

public class GetDataGroupsQuery : IRequest<List<DataGroup>>
{

}
