using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.DataTemplates.Queries.GetDataTemplate;

public class GetDataTemplateQuery : IRequest<DataTemplate>
{
    public Guid DataTemplateId { get; set; }

    public GetDataTemplateQuery(Guid dataTemplateId)
    {
        DataTemplateId = dataTemplateId;
    }
}
