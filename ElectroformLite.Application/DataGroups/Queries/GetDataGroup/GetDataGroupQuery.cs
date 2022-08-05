using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.DataGroups.Queries.GetDataGroup;

public class GetDataGroupQuery : IRequest<DataGroup>
{
    public int DataGroupId { get; set; }
}
