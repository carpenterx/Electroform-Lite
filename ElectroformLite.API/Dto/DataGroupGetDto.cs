namespace ElectroformLite.API.Dto;

public class DataGroupGetDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public List<DataGetPutDto> UserData { get; set; }
}
