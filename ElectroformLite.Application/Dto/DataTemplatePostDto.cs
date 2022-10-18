using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Dto;

public class DataTemplatePostDto
{
    public Guid DataTypeId { get; set; }
    public string Placeholder { get; set; }
}
