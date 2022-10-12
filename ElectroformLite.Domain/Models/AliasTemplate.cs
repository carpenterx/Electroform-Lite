using System.ComponentModel.DataAnnotations;

namespace ElectroformLite.Domain.Models;

public class AliasTemplate
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    public Guid DataGroupTemplateId { get; set; }
    public Guid TemplateId { get; set; }

    public DataGroupTemplate DataGroupTemplate { get; set; }
    public Template Template { get; set; }
    //public ICollection<Template> Templates { get; set; }
    public ICollection<Alias> Aliases { get; set; }

    public AliasTemplate(string name)
    {
        Name = name;
        //Templates = new HashSet<Template>();
        Aliases = new HashSet<Alias>();
    }
}
