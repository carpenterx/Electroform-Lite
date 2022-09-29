using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.AliasTemplates.Queries.GetAliasTemplate;

public class GetAliasTemplateQueryHandler : IRequestHandler<GetAliasTemplateQuery, AliasTemplate?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAliasTemplateQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AliasTemplate?> Handle(GetAliasTemplateQuery request, CancellationToken cancellationToken)
    {
        AliasTemplate? aliasTemplate = await _unitOfWork.AliasTemplateRepository.GetAliasTemplateWithDataGroupTemplate(request.AliasTemplateId);

        return aliasTemplate;
    }
}