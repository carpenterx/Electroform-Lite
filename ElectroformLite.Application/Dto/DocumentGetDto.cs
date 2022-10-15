namespace ElectroformLite.Application.Dto;

public class DocumentGetDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Content { get; set; }

    public Guid TemplateId { get; set; }
}
