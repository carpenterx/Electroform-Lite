using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Templates.Queries.GetTemplates;

public class GetTemplatesQueryHandler : IRequestHandler<GetTemplatesQuery, List<Template>>
{
    private readonly ITemplateRepository _repository;

    public GetTemplatesQueryHandler(ITemplateRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Template>> Handle(GetTemplatesQuery request, CancellationToken cancellationToken)
    {
        var result = _repository.GetTemplates();

        return Task.FromResult(result);
    }
}