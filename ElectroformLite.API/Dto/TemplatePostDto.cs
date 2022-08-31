namespace ElectroformLite.API.Dto;

public class TemplatePostDto
{
    public string Name { get; set; }
    public string Content { get; set; }
    public List<Guid> DataGroupTemplateIds { get; set; }
}
