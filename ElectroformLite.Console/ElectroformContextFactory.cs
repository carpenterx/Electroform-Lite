using ElectroformLite.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ElectroformLite.Console;

public class ElectroformContextFactory : IDesignTimeDbContextFactory<ElectroformDbContext>
{
    public ElectroformDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ElectroformDbContext>();
        optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=electroform;Integrated Security=True", b => b.MigrationsAssembly("ElectroformLite.Console"));

        return new ElectroformDbContext(optionsBuilder.Options);
    }
}
