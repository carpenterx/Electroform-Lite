namespace ElectroformLite.Application.Dto;

public class TemplateGetDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Content { get; set; }

    public ICollection<AliasTemplateDto> AliasTemplates { get; set; }
}
