namespace ElectroformLite.Application.Dto;

public class DataGroupPutDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    // data id and value
    public Dictionary<Guid, string> UserData { get; set; }
}
