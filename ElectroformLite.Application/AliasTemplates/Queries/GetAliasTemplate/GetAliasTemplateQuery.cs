using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.AliasTemplates.Queries.GetAliasTemplate;

public class GetAliasTemplateQuery : IRequest<AliasTemplate?>
{
    public Guid AliasTemplateId { get; set; }

    public GetAliasTemplateQuery(Guid aliasTemplateId)
    {
        AliasTemplateId = aliasTemplateId;
    }
}
