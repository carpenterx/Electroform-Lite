namespace ElectroformLite.Application.Dto;

public class DocumentPostDto
{
    public string DocumentName { get; set; }
    public Guid TemplateId { get; set; }
    //public List<Guid> DataGroupIds { get; set; }
    // alias template guid and data group guid
    public Dictionary<Guid, Guid> AliasData { get; set; }
}
