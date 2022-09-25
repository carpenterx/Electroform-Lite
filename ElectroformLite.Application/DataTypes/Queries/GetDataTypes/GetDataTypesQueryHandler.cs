using ElectroformLite.Application.Exceptions;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;
using System.Net;

namespace ElectroformLite.Application.DataTypes.Queries.GetDataTypes;

public class GetDataTypesQueryHandler : IRequestHandler<GetDataTypesQuery, List<DataType>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDataTypesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<DataType>> Handle(GetDataTypesQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.DataTypeRepository.GetDataTypes();
    }
}
