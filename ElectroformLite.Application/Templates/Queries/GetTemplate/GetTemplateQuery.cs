using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Templates.Queries.GetTemplates;

public class GetTemplateQuery : IRequest<Template>
{
    public int TemplateId { get; set; }

    public GetTemplateQuery(int templateId)
    {
        TemplateId = templateId;
    }
}
