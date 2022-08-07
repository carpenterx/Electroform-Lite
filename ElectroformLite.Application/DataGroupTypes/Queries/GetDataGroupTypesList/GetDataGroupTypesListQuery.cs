using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.DataGroupTypes.Queries.GetDataGroupTypesList;

public class GetDataGroupTypesListQuery : IRequest<List<DataGroupType>>
{

}
