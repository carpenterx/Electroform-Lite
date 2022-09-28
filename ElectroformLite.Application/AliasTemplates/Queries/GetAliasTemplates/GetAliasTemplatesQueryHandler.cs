using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.AliasTemplates.Queries.GetAliasTemplates;

public class GetAliasTemplatesQueryHandler : IRequestHandler<GetAliasTemplatesQuery, List<AliasTemplate>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAliasTemplatesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<AliasTemplate>> Handle(GetAliasTemplatesQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.AliasTemplateRepository.GetAliasTemplates();
    }
}
