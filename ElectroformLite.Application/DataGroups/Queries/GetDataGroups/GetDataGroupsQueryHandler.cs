using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroups.Queries.GetDataGroups;

public class GetDataGroupsQueryHandler : IRequestHandler<GetDataGroupsQuery, List<DataGroup>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDataGroupsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<DataGroup>> Handle(GetDataGroupsQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.DataGroupRepository.GetDataGroups();
    }
}
