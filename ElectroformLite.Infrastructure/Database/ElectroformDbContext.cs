using ElectroformLite.Domain.Models;
using ElectroformLite.Infrastructure.Database.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ElectroformLite.Infrastructure.Database;

public class ElectroformDbContext : IdentityDbContext<User>
{
    public DbSet<Data> UserData { get; set; }
    public DbSet<DataGroup> DataGroups { get; set; }
    public DbSet<DataGroupTemplate> DataGroupTemplates { get; set; }
    public DbSet<DataGroupType> DataGroupTypes { get; set; }
    public DbSet<DataTemplate> DataTemplates { get; set; }
    public DbSet<DataType> DataTypes { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<Template> Templates { get; set; }
    public DbSet<Alias> Aliases { get; set; }
    public DbSet<AliasTemplate> AliasTemplates { get; set; }
    //public DbSet<User> Users { get; set; }

    public ElectroformDbContext(DbContextOptions<ElectroformDbContext> dbContextOptions) : base(dbContextOptions)
    {

    }

    /*protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=electroform;Integrated Security=True");
    }*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DocumentConfiguration());
        //modelBuilder.ApplyConfiguration(new DataConfiguration());
        //modelBuilder.ApplyConfiguration(new UserConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
