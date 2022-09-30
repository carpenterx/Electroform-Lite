using ElectroformLite.Application.Exceptions;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;
using System.Net;

namespace ElectroformLite.Application.AliasTemplates.Queries.GetAliasTemplate;

public class GetAliasTemplateQueryHandler : IRequestHandler<GetAliasTemplateQuery, AliasTemplate>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAliasTemplateQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AliasTemplate> Handle(GetAliasTemplateQuery request, CancellationToken cancellationToken)
    {
        AliasTemplate? aliasTemplate = await _unitOfWork.AliasTemplateRepository.GetAliasTemplateWithDataGroupTemplate(request.AliasTemplateId);

        if (aliasTemplate == null)
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                ReasonPhrase = "Alias Template Not Found"
            };
            throw new NotFoundHttpResponseException(response);
        }

        return aliasTemplate;
    }
}