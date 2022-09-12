using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTypes.Queries.GetDataGroupTypes;

public class GetDataGroupTypesQueryHandler : IRequestHandler<GetDataGroupTypesQuery, List<DataGroupType>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDataGroupTypesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<DataGroupType>> Handle(GetDataGroupTypesQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.DataGroupTypeRepository.GetDataGroupTypes();
    }
}
