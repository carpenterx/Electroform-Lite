namespace ElectroformLite.Application.Dto;

public class DataGroupGetDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public List<DataGetDto> UserData { get; set; }

    public DataGroupTemplateDto DataGroupTemplate { get; set; }
}
