using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Templates.Queries.GetTemplate;

public class GetTemplateQueryHandler : IRequestHandler<GetTemplateQuery, Template?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTemplateQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Template?> Handle(GetTemplateQuery request, CancellationToken cancellationToken)
    {
        Template? template = await _unitOfWork.TemplateRepository.GetTemplate(request.TemplateId);

        return template;
    }
}