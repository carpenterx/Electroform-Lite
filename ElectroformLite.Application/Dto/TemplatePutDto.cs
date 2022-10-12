namespace ElectroformLite.Application.Dto;

public class TemplatePutDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }

    //public Dictionary<Guid, string> AliasTemplateData { get; set; }
    public List<AliasTemplateData> AliasTemplatesData { get; set; }
}
