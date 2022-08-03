using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.DataTypes.Queries.GetDataTypesList;

public class GetDataTypesListQuery : IRequest<List<DataType>>
{

}
