namespace ElectroformLite.Application.Dto;

public class DataTemplateGetDto
{
    public Guid Id { get; set; }

    public string Placeholder { get; set; }

    public DataTypeDto DataType { get; set; }
}
