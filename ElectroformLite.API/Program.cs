using ElectroformLite.API.Middleware;
using ElectroformLite.API.Utils;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Application.Profiles;
using ElectroformLite.Application.Utils;
using ElectroformLite.Domain.Models;
using ElectroformLite.Infrastructure;
using ElectroformLite.Infrastructure.Database;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ElectroformDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = "http://localhost:4200",
        ValidIssuer = "https://localhost:7188",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("SecurityKey")))
    };
});

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
builder.Services.AddAutoMapper(typeof(ElectroformProfiles));

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IUriService>(o =>
{
    var accessor = o.GetRequiredService<IHttpContextAccessor>();
    var request = accessor.HttpContext.Request;
    var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
    return new UriService(uri);
});

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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ElectroformDbContext>();
    context.Database.EnsureCreated();
    //DatabaseHelper.Initialize(context);
    //await DatabaseHelper.FixTemplatesContent(context);
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ErrorLoggingMiddleware>();

app.MapControllers();

app.Run();