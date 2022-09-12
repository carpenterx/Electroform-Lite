using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroups.Queries.GetDataGroup;

public class GetDataGroupQueryHandler : IRequestHandler<GetDataGroupQuery, DataGroup?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDataGroupQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataGroup?> Handle(GetDataGroupQuery request, CancellationToken cancellationToken)
    {
        DataGroup? dataGroup = await _unitOfWork.DataGroupRepository.GetDataGroup(request.DataGroupId);

        return dataGroup;
    }
}