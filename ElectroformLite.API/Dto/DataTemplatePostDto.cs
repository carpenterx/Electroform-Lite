using ElectroformLite.Domain.Models;

namespace ElectroformLite.API.Dto;

public class DataTemplatePostDto
{
    public Guid DataTypeId { get; set; }
    public string Placeholder { get; set; }
}
