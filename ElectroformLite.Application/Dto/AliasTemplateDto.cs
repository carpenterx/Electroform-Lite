namespace ElectroformLite.Application.Dto;

public class AliasTemplateDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public DataGroupTemplateDto DataGroupTemplate { get; set; }
}
