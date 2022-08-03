using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.DataGroupTypes.Queries;

public class GetDataGroupTypesListQuery : IRequest<List<DataGroupType>>
{

}
