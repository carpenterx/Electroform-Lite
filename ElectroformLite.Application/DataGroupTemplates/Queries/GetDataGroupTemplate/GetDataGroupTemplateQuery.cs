using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.DataGroupTemplates.Queries.GetDataGroupTemplate;

public class GetDataGroupTemplateQuery : IRequest<DataGroupTemplate?>
{
    public Guid DataGroupTemplateId { get; set; }

    public GetDataGroupTemplateQuery(Guid dataGroupTemplateId)
    {
        DataGroupTemplateId = dataGroupTemplateId;
    }
}
