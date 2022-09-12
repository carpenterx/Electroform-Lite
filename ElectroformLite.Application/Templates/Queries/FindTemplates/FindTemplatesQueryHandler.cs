using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Templates.Queries.FindTemplates;

public class FindTemplatesQueryHandler : IRequestHandler<FindTemplatesQuery, List<Template>>
{
    private readonly ITemplateRepository _repository;

    public FindTemplatesQueryHandler(ITemplateRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Template>> Handle(FindTemplatesQuery request, CancellationToken cancellationToken)
    {
        var result = _repository.FindTemplates(request.SearchTerm);

        return result;
    }
}