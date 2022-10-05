namespace ElectroformLite.Application.Dto;

public class AliasTemplateGetDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public DataGroupTemplateGetDto DataGroupTemplate { get; set; }
}
