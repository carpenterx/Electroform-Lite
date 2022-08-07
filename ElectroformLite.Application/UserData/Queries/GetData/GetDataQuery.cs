using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.UserData.Queries.GetData;

public class GetDataQuery : IRequest<Data>
{
    public int DataId { get; set; }

    public GetDataQuery(int dataId)
    {
        DataId = dataId;
    }
}
