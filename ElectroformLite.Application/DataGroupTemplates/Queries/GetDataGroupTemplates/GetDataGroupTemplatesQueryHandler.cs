using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTemplates.Queries.GetDataGroupTemplates;

public class GetDataGroupTemplatesQueryHandler : IRequestHandler<GetDataGroupTemplatesQuery, List<DataGroupTemplate>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDataGroupTemplatesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<DataGroupTemplate>> Handle(GetDataGroupTemplatesQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.DataGroupTemplateRepository.GetDataGroupTemplates();
    }
}
