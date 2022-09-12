using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.DataGroups.Queries.GetDataGroup;

public class GetDataGroupQuery : IRequest<DataGroup?>
{
    public Guid DataGroupId { get; set; }

    public GetDataGroupQuery(Guid dataGroupId)
    {
        DataGroupId = dataGroupId;
    }
}
