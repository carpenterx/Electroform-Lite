using ElectroformLite.Application.Interfaces;
using ElectroformLite.Console;
using ElectroformLite.Infrastructure;
using ElectroformLite.Infrastructure.Database;
using ElectroformLite.Infrastructure.InMemory;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ElectroformLite.ConsolePresentation;

internal class Program
{
    private static void Main(string[] args)
    {
        var mediator = Init();

        ApplicationManager applicationManager = new(mediator);
        applicationManager.StartApplication();
    }

    private static IMediator Init()
    {
        /*var optionsBuilder = new DbContextOptionsBuilder();
        optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=electroform;Integrated Security=True", b => b.MigrationsAssembly("ElectroformLite.Console"));
        Action<DbContextOptionsBuilder> optionsAction = new Action<DbContextOptionsBuilder>(optionsBuilder);*/
        var diContainer = new ServiceCollection()
            .AddMediatR(typeof(IDataRepository))
            .AddDbContext<ElectroformDbContext>()
            .AddScoped<IDataRepository, InMemoryDataRepository>()
            .AddScoped<IDataTypeRepository, InMemoryDataTypeRepository>()
            .AddScoped<IDataGroupRepository, InMemoryDataGroupRepository>()
            .AddScoped<IDataGroupTemplateRepository, InMemoryDataGroupTemplateRepository>()
            .AddScoped<IDataGroupTypeRepository, DataGroupTypeRepository>()
            .AddScoped<IDataTemplateRepository, InMemoryDataTemplateRepository>()
            .AddScoped<IDocumentRepository, InMemoryDocumentRepository>()
            .AddScoped<ITemplateRepository, InMemoryTemplateRepository>()
            .AddScoped<IUserRepository, InMemoryUserRepository>()
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .BuildServiceProvider();

        return diContainer.GetRequiredService<IMediator>();
    }
}

