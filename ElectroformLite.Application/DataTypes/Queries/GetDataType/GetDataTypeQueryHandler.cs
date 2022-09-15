using ElectroformLite.Application.Exceptions;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;
using System.Net;

namespace ElectroformLite.Application.DataTypes.Queries.GetDataType;

public class GetDataTypeQueryHandler : IRequestHandler<GetDataTypeQuery, DataType>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDataTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataType> Handle(GetDataTypeQuery request, CancellationToken cancellationToken)
    {
        DataType? dataType = await _unitOfWork.DataTypeRepository.GetDataType(request.DataTypeId);

        if (dataType == null)
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                ReasonPhrase = "Data Type Not Found"
            };
            throw new NotFoundHttpResponseException(response);
        }

        return dataType;
    }
}
