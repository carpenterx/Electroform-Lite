namespace ElectroformLite.Domain.Models;

public class TemplatesDataGroupTemplates
{
    public Guid Id { get; set; }
    public Guid TemplateId { get; set; }
    public Template Template { get; set; }
    public Guid DataGroupTemplateId { get; set; }
    public DataGroupTemplate DataGroupTemplate { get; set; }
}
