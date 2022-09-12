using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.UserData.Queries.GetDataList;

public class GetDataListQueryHandler : IRequestHandler<GetDataListQuery, List<Data>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDataListQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Data>> Handle(GetDataListQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.DataRepository.GetAllData();
    }
}
