namespace ElectroformLite.API.Dto;

public class DataGroupPostDto
{
    public Guid DataGroupTemplateId { get; set; }
    public string Name { get; set; }
    // data template guid + data value
    public List<KeyValuePair<Guid, string>> DataProperties { get; set; }
}
