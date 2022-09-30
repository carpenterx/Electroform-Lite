using MediatR;

namespace ElectroformLite.Application.AliasTemplates.Queries.GetAliasTemplateId;

public class GetAliasTemplateIdQuery : IRequest<Guid>
{
    public Guid DataGroupTemplateId { get; set; }

    public GetAliasTemplateIdQuery(Guid dataGroupTemplateId)
    {
        DataGroupTemplateId = dataGroupTemplateId;
    }
}
