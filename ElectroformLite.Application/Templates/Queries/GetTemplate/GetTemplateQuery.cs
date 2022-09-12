using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Templates.Queries.GetTemplate;

public class GetTemplateQuery : IRequest<Template?>
{
    public Guid TemplateId { get; set; }

    public GetTemplateQuery(Guid templateId)
    {
        TemplateId = templateId;
    }
}
