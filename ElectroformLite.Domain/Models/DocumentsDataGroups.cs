namespace ElectroformLite.Domain.Models;

public class DocumentsDataGroups
{
    public Guid Id { get; set; }
    public Guid DocumentId { get; set; }
    public Document Document { get; set; }
    public Guid DataGroupId { get; set; }
    public DataGroup DataGroup { get; set; }
}
