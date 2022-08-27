using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataTemplates.Queries.GetDataTemplates;

public class GetDataTemplatesQueryHandler : IRequestHandler<GetDataTemplatesQuery, List<DataTemplate>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDataTemplatesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<DataTemplate>> Handle(GetDataTemplatesQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.DataTemplateRepository.GetDataTemplates();
    }
}