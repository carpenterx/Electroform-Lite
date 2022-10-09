namespace ElectroformLite.Application.Dto;

public class DataGroupTemplateGetDto
{
    public Guid Id { get; set; }

    //public string Name { get; set; }

    public ICollection<DataTemplateGetPutDto> DataTemplates { get; set; }

    public DataGroupTypeDto DataGroupType { get; set; }
}