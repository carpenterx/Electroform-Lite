using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.DataGroupTypes.Queries.GetDataGroupType;

public class GetDataGroupTypeQuery : IRequest<DataGroupType>
{
    public Guid DataGroupTypeId { get; set; }

    public GetDataGroupTypeQuery(Guid dataGroupTypeId)
    {
        DataGroupTypeId = dataGroupTypeId;
    }
}
