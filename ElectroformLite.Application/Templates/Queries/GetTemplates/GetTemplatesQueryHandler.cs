using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Templates.Queries.GetTemplates;

public class GetTemplatesQueryHandler : IRequestHandler<GetTemplatesQuery, List<Template>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTemplatesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Template>> Handle(GetTemplatesQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.TemplateRepository.GetTemplates();
    }
}