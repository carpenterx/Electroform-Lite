using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTemplates.Queries;

public class GetDataGroupTemplatesListQueryHandler : IRequestHandler<GetDataGroupTemplatesListQuery, List<DataGroupTemplate>>
{
    private readonly IDataGroupTemplateRepository _repository;

    public GetDataGroupTemplatesListQueryHandler(IDataGroupTemplateRepository repository)
    {
        _repository = repository;
    }

    public Task<List<DataGroupTemplate>> Handle(GetDataGroupTemplatesListQuery request, CancellationToken cancellationToken)
    {
        var result = _repository.GetDataGroupTemplates();

        return Task.FromResult(result);
    }
}
