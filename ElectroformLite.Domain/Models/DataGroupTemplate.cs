namespace ElectroformLite.Domain.Models;

public class DataGroupTemplate
{
    public Guid Id { get; set; }

    /*[Required]
    [StringLength(100)]
    public string Name { get; set; }*/

    public Guid DataGroupTypeId { get; set; }

    public DataGroupType DataGroupType { get; set; }
    public ICollection<DataGroup> DataGroups { get; set; }
    public ICollection<DataTemplate> DataTemplates { get; set; }
    public ICollection<AliasTemplate> AliasTemplates { get; set; }
    //public ICollection<Template> Templates { get; set; }

    public DataGroupTemplate()
    {
        DataGroups = new HashSet<DataGroup>();
        DataTemplates = new HashSet<DataTemplate>();
        AliasTemplates = new HashSet<AliasTemplate>();
        //Templates = new HashSet<Template>();
    }
}
