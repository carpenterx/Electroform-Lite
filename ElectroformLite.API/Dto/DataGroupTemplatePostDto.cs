namespace ElectroformLite.API.Dto;

public class DataGroupTemplatePostDto
{
    public Guid DataGroupTypeId { get; set; }
    //public string Name { get; set; }
    public List<Guid> DataTemplateIds { get; set; }
}
