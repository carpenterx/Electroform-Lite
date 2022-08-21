using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.DataGroups.Queries.GetDataGroupsByType;

public class GetDataGroupsByTypeQuery : IRequest<List<DataGroup>>
{
   /* public int TypeId { get; set; }

    public GetDataGroupsByTypeQuery(int typeId)
    {
        TypeId = typeId;
    }*/
}
