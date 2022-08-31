namespace ElectroformLite.API.Dto;

public class DocumentPostDto
{
    public Guid TemplateId { get; set; }
    public List<Guid> DataGroupIds { get; set; }
}
