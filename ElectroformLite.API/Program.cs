using ElectroformLite.API.Controllers;
using ElectroformLite.API.Middleware;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Infrastructure;
using ElectroformLite.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
        });
});

// Add services to the container.
builder.Services.AddDbContext<ElectroformDbContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("Local")));
builder.Services.AddMediatR(typeof(IDataRepository));

builder.Services.AddScoped<IDataRepository, DataRepository>();
builder.Services.AddScoped<IDataTypeRepository, DataTypeRepository>();
builder.Services.AddScoped<IDataGroupRepository, DataGroupRepository>();
builder.Services.AddScoped<IDataGroupTemplateRepository, DataGroupTemplateRepository>();
builder.Services.AddScoped<IDataGroupTypeRepository, DataGroupTypeRepository>();
builder.Services.AddScoped<IDataTemplateRepository, DataTemplateRepository>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<ITemplateRepository, TemplateRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAliasTemplateRepository, AliasTemplateRepository>();
builder.Services.AddScoped<IAliasRepository, AliasRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(DataGroupTypesController));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.UseMiddleware<ErrorLoggingMiddleware>();

app.MapControllers();

app.Run();