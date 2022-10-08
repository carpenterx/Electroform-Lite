using ElectroformLite.Application.Exceptions;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Application.Utils;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Templates.Queries.GetTemplate;

public class GetTemplateQueryHandler : IRequestHandler<GetTemplateQuery, Template>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTemplateQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Template> Handle(GetTemplateQuery request, CancellationToken cancellationToken)
    {
        Template? template = await _unitOfWork.TemplateRepository.GetTemplateWithAliasTemplates(request.TemplateId);

        if (template == null)
        {
            HttpResponseMessage response = HttpUtilities.HttpResponseMessageBuilder("Template Not Found");
            throw new NotFoundHttpResponseException(response);
        }

        return template;
    }
}