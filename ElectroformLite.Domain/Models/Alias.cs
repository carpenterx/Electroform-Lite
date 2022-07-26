﻿namespace ElectroformLite.Domain.Models;

public class Alias
{
    public Guid Id { get; set; }
    public Guid AliasTemplateId { get; set; }
    public Guid DataGroupId { get; set; }
    public Guid DocumentId { get; set; }

    public AliasTemplate AliasTemplate { get; set; }
    public DataGroup DataGroup { get; set; }
    public Document Document { get; set; }
}
