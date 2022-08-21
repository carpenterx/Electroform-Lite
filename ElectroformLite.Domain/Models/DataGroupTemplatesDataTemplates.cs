namespace ElectroformLite.Domain.Models;

public class DataGroupTemplatesDataTemplates
{
    public Guid Id { get; set; }
    public Guid DataGroupTemplateId { get; set; }
    public DataGroupTemplate DataGroupTemplate { get; set; }
    public Guid DataTemplateId { get; set; }
    public DataTemplate DataTemplate { get; set; }
}
