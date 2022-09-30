using ElectroformLite.Application.Exceptions;
using ElectroformLite.Application.Interfaces;
using MediatR;
using System.Net;

namespace ElectroformLite.Application.AliasTemplates.Queries.GetAliasTemplateId;

public class GetAliasTemplateIdQueryHandler : IRequestHandler<GetAliasTemplateIdQuery, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAliasTemplateIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(GetAliasTemplateIdQuery request, CancellationToken cancellationToken)
    {
        Guid? aliasTemplateId = await _unitOfWork.AliasTemplateRepository.GetAliasTemplateId(request.DataGroupTemplateId);

        if (aliasTemplateId == null)
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                ReasonPhrase = "Alias Template Id Not Found"
            };
            throw new NotFoundHttpResponseException(response);
        }

        return (Guid)aliasTemplateId;
    }
}