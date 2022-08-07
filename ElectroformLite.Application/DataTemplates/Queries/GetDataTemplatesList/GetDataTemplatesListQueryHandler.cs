using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataTemplates.Queries.GetDataTemplatesList;

public class GetDataTemplatesListQueryHandler : IRequestHandler<GetDataTemplatesListQuery, List<DataTemplate>>
{
    private readonly IDataTemplateRepository _repository;

    public GetDataTemplatesListQueryHandler(IDataTemplateRepository repository)
    {
        _repository = repository;
    }

    public Task<List<DataTemplate>> Handle(GetDataTemplatesListQuery request, CancellationToken cancellationToken)
    {
        var result = _repository.GetDataTemplates();

        return Task.FromResult(result);
    }
}