using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataTemplates.Queries.GetDataTemplate;

public class GetDataTemplateQueryHandler : IRequestHandler<GetDataTemplateQuery, DataTemplate>
{
    private readonly IDataTemplateRepository _repository;

    public GetDataTemplateQueryHandler(IDataTemplateRepository repository)
    {
        _repository = repository;
    }

    public Task<DataTemplate> Handle(GetDataTemplateQuery request, CancellationToken cancellationToken)
    {
        var result = _repository.GetDataTemplate(request.DataTemplateId);

        return Task.FromResult(result);
    }
}