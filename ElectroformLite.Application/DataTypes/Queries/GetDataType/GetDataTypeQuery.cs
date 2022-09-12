using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.DataTypes.Queries.GetDataType;

public class GetDataTypeQuery : IRequest<DataType?>
{
    public Guid DataTypeId { get; set; }

    public GetDataTypeQuery(Guid dataTypeId)
    {
        DataTypeId = dataTypeId;
    }
}
