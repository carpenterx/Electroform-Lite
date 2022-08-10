using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.DataGroupTypes.Queries.GetDataGroupTypes;

public class GetDataGroupTypesQuery : IRequest<List<DataGroupType>>
{

}
