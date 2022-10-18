using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.DataGroups.Queries.GetDataGroupsByType;

public class GetDataGroupsByTypeQuery : IRequest<List<DataGroup>>
{
    public Guid DataGroupTypeId { get; set; }

    public GetDataGroupsByTypeQuery(Guid dataGroupTypeId)
    {
        DataGroupTypeId = dataGroupTypeId;
    }
}
