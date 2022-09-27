using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroups.Queries.GetDataGroupsByType;

public class GetDataGroupsByTypeQueryHandler : IRequestHandler<GetDataGroupsByTypeQuery, List<DataGroup>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDataGroupsByTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<DataGroup>> Handle(GetDataGroupsByTypeQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.DataGroupRepository.GetDataGroupsByType(request.DataGroupTypeId);
    }
}
