namespace ElectroformLite.Application.Dto;

public class DataGroupTemplatePutDto
{
    public Guid Id { get; set; }

    //public string Name { get; set; }

    public List<Guid> DataTemplateIds { get; set; }
}
