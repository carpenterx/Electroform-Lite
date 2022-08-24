using ElectroformLite.API.Controllers;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Infrastructure;
using ElectroformLite.Infrastructure.Database;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ElectroformDbContext>(o =>
    o.UseSqlServer(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=electroform;Integrated Security=True"));
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

app.UseAuthorization();

app.MapControllers();

app.Run();
