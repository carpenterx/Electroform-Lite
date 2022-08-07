using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTemplates.Queries.GetDataGroupTemplate;

public class GetDataGroupTemplateQueryHandler : IRequestHandler<GetDataGroupTemplateQuery, DataGroupTemplate>
{
    private readonly IDataGroupTemplateRepository _repository;

    public GetDataGroupTemplateQueryHandler(IDataGroupTemplateRepository repository)
    {
        _repository = repository;
    }

    public Task<DataGroupTemplate> Handle(GetDataGroupTemplateQuery request, CancellationToken cancellationToken)
    {
        var result = _repository.GetDataGroupTemplate(request.DataGroupTemplateId);

        return Task.FromResult(result);
    }
}
