using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataTemplates.Queries.GetDataTemplate;

public class GetDataTemplateQueryHandler : IRequestHandler<GetDataTemplateQuery, DataTemplate?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDataTemplateQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataTemplate?> Handle(GetDataTemplateQuery request, CancellationToken cancellationToken)
    {
        DataTemplate? dataTemplate = await _unitOfWork.DataTemplateRepository.GetDataTemplate(request.DataTemplateId);

        return dataTemplate;
    }
}