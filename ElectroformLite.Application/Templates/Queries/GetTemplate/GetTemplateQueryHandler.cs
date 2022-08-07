using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Templates.Queries.GetTemplates;

public class GetTemplateQueryHandler : IRequestHandler<GetTemplateQuery, Template>
{
    private readonly ITemplateRepository _repository;

    public GetTemplateQueryHandler(ITemplateRepository repository)
    {
        _repository = repository;
    }

    public Task<Template> Handle(GetTemplateQuery request, CancellationToken cancellationToken)
    {
        var result = _repository.GetTemplate(request.TemplateId);

        return Task.FromResult(result);
    }
}