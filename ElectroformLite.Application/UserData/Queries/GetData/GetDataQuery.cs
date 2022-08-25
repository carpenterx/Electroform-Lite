using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.UserData.Queries.GetData;

public class GetDataQuery : IRequest<Data?>
{
    public Guid DataId { get; set; }

    public GetDataQuery(Guid dataId)
    {
        DataId = dataId;
    }
}
