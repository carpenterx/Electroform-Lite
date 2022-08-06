using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.DataGroupTypes.Queries.GetDataGroupType;

public class GetDataGroupTypeQuery : IRequest<DataGroupType>
{
    public int DataGroupTypeId { get; set; }

    public GetDataGroupTypeQuery(int dataGroupTypeId)
    {
        DataGroupTypeId = dataGroupTypeId;
    }
}
