namespace ElectroformLite.Application.Dto;

public class DataGetDto
{
    public Guid Id { get; set; }

    public string Value { get; set; }

    public DataTemplateGetPutDto DataTemplate { get; set; }
}
