using ElectroformLite.Application.Interfaces;
using ElectroformLite.Infrastructure.Database;
using ElectroformLite.Infrastructure.InMemory;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ElectroformLite.ConsolePresentation;

internal class Program
{
    private static void Main(string[] args)
    {
        var diContainer = new ServiceCollection()
            .AddMediatR(typeof(IDataRepository))
            .AddScoped<IDataRepository, InMemoryDataRepository>()
            .AddScoped<IDataTypeRepository, InMemoryDataTypeRepository>()
            .AddScoped<IDataGroupRepository, InMemoryDataGroupRepository>()
            .AddScoped<IDataGroupTemplateRepository, InMemoryDataGroupTemplateRepository>()
            .AddScoped<IDataGroupTypeRepository, InMemoryDataGroupTypeRepository>()
            .AddScoped<IDataTemplateRepository, InMemoryDataTemplateRepository>()
            .AddScoped<IDocumentRepository, InMemoryDocumentRepository>()
            .AddScoped<ITemplateRepository, InMemoryTemplateRepository>()
            .AddScoped<IUserRepository, InMemoryUserRepository>()
            .AddScoped<IElectroformDbContext, ElectroformDbContext>()
            .BuildServiceProvider();

        var mediator = diContainer.GetRequiredService<IMediator>();
        var electroformDbContext = diContainer.GetRequiredService<IElectroformDbContext>();

        ApplicationManager applicationManager = new ApplicationManager(mediator, electroformDbContext);
        applicationManager.StartApplication();
    }
}

