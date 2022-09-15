using ElectroformLite.Infrastructure.Database;
using ElectroformLite.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ElectroformLite.IntegrationTests;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    private SqliteConnection _sqliteConnection;

    public CustomWebApplicationFactory()
    {
        _sqliteConnection = new SqliteConnection("DataSource=:memory:");
        _sqliteConnection.Open();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        //base.ConfigureWebHost(builder);
        builder.ConfigureServices(services =>
        {
            var serviceDescriptor = services.SingleOrDefault(s => s.ServiceType == typeof(DbContextOptions<ElectroformDbContext>));
            services.Remove(serviceDescriptor);

            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlite()
                .BuildServiceProvider();

            services.AddDbContext<ElectroformDbContext>(options =>
            {
                options.UseSqlite(_sqliteConnection);
                options.UseInternalServiceProvider(serviceProvider);

            }, ServiceLifetime.Scoped);

            var sp = services.BuildServiceProvider();

            using (var scope = sp.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;

                var db = scopedServices.GetRequiredService<ElectroformDbContext>();

                db.Database.EnsureDeleted();

                db.Database.EnsureCreated();

                Utilities.InitializeDbForTests(db);
            }

        });
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        _sqliteConnection.Close();
        _sqliteConnection.Dispose();
    }
}
