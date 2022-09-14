using ElectroformLite.Application.Exceptions;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;
using System.Net;

namespace ElectroformLite.Application.DataGroupTypes.Queries.GetDataGroupType;

public class GetDataGroupTypeQueryHandler : IRequestHandler<GetDataGroupTypeQuery, DataGroupType>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDataGroupTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataGroupType> Handle(GetDataGroupTypeQuery request, CancellationToken cancellationToken)
    {
        DataGroupType? dataGroupType = await _unitOfWork.DataGroupTypeRepository.GetDataGroupType(request.DataGroupTypeId);

        if (dataGroupType == null)
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                ReasonPhrase = "Data Group Type Not Found"
            };
            throw new NotFoundHttpResponseException(response);
        }

        return dataGroupType;
    }
}
