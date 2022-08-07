using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Templates.Queries.FindTemplates;

public class FindTemplatesQuery : IRequest<List<Template>>
{
    public string SearchTerm { get; set; }

    public FindTemplatesQuery(string searchTerm)
    {
        SearchTerm = searchTerm;
    }
}
