using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.DataGroupTemplates.Queries.GetDataGroupTemplate;

public class GetDataGroupTemplateQuery : IRequest<DataGroupTemplate>
{
    public int DataGroupTemplateId { get; set; }

    public GetDataGroupTemplateQuery(int dataGroupTemplateId)
    {
        DataGroupTemplateId = dataGroupTemplateId;
    }
}
