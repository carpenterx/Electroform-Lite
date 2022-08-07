using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.DataTemplates.Queries.GetDataTemplate;

public class GetDataTemplateQuery : IRequest<DataTemplate>
{
    public int DataTemplateId { get; set; }

    public GetDataTemplateQuery(int dataTemplateId)
    {
        DataTemplateId = dataTemplateId;
    }
}
