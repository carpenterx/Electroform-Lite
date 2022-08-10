using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataTemplates.Queries.GetDataTemplates;

public class GetDataTemplatesQueryHandler : IRequestHandler<GetDataTemplatesQuery, List<DataTemplate>>
{
    private readonly IDataTemplateRepository _repository;

    public GetDataTemplatesQueryHandler(IDataTemplateRepository repository)
    {
        _repository = repository;
    }

    public Task<List<DataTemplate>> Handle(GetDataTemplatesQuery request, CancellationToken cancellationToken)
    {
        var result = _repository.GetDataTemplates();

        return Task.FromResult(result);
    }
}