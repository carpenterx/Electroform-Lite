using ElectroformLite.Application.Interfaces;
using ElectroformLite.Infrastructure;
using ElectroformLite.Infrastructure.Database;
using ElectroformLite.Infrastructure.InMemory;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ElectroformDbContext>(o =>
    o.UseSqlServer(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=electroform;Integrated Security=True"));
builder.Services.AddMediatR(typeof(IDataRepository));

builder.Services.AddScoped<IDataRepository, InMemoryDataRepository>();
builder.Services.AddScoped<IDataTypeRepository, InMemoryDataTypeRepository>();
builder.Services.AddScoped<IDataGroupRepository, InMemoryDataGroupRepository>();
builder.Services.AddScoped<IDataGroupTemplateRepository, InMemoryDataGroupTemplateRepository>();
//builder.Services.AddScoped<IDataGroupTypeRepository, DataGroupTypeRepository>();
builder.Services.AddScoped<IDataGroupTypeRepository, DataGroupTypeRepository>();
builder.Services.AddScoped<IDataTemplateRepository, InMemoryDataTemplateRepository>();
builder.Services.AddScoped<IDocumentRepository, InMemoryDocumentRepository>();
builder.Services.AddScoped<ITemplateRepository, InMemoryTemplateRepository>();
builder.Services.AddScoped<IUserRepository, InMemoryUserRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
