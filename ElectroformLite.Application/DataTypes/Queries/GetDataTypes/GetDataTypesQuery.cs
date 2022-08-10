using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.DataTypes.Queries.GetDataTypes;

public class GetDataTypesQuery : IRequest<List<DataType>>
{

}
