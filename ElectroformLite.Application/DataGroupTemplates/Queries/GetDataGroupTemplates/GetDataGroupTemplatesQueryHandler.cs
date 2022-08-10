using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTemplates.Queries.GetDataGroupTemplates;

public class GetDataGroupTemplatesQueryHandler : IRequestHandler<GetDataGroupTemplatesQuery, List<DataGroupTemplate>>
{
    private readonly IDataGroupTemplateRepository _repository;

    public GetDataGroupTemplatesQueryHandler(IDataGroupTemplateRepository repository)
    {
        _repository = repository;
    }

    public Task<List<DataGroupTemplate>> Handle(GetDataGroupTemplatesQuery request, CancellationToken cancellationToken)
    {
        var result = _repository.GetDataGroupTemplates();

        return Task.FromResult(result);
    }
}
