using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Templates.Queries.GetTemplate;

public class GetTemplateQuery : IRequest<Template>
{
    public int TemplateId { get; set; }

    public GetTemplateQuery(int templateId)
    {
        TemplateId = templateId;
    }
}
