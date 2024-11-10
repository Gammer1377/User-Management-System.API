using System.Text;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using User_Management_System.Data.Context;
using User_Management_System.Data.Contracts;
using User_Management_System.Data.Repositories;
using User_Management_System.Entities.DTOs.User;
using User_Management_System.Entities.Validators;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

var builder = WebApplication.CreateBuilder(args);
string template = "{Timestamp:yyyy/MM/dd - HH:mm:ss zzz} [{Level:u3}] {Message:lj} {NewLine} {Exception}";
string path = "SeriLog/log.txt";
#region SinkToConsole

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(theme: AnsiConsoleTheme.Code)
    .CreateLogger();

#endregion

#region SinkToFile

Log.Logger = new LoggerConfiguration()
    .WriteTo.File(path, rollingInterval: RollingInterval.Day, fileSizeLimitBytes: 12000, rollOnFileSizeLimit: true, retainedFileCountLimit: 10,outputTemplate:template)
    .CreateLogger();

#endregion

builder.Host.UseSerilog();
// Add services to the container.
#region JWT

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"])
            )
        };
    });

#endregion

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "UserManagementSystem",
        Version = "V1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter Token"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
         {
         new OpenApiSecurityScheme
         {
             Reference = new OpenApiReference
             {
                 Type = ReferenceType.SecurityScheme,
                 Id = "Bearer"
             }

        },
         new string[]{ }
        }
    });
});

#region Context

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});

#endregion

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
builder.Services.AddScoped<IValidator<CreateUserDTO>, CreateUserDTOValidation>();
builder.Services.AddScoped<IValidator<UpdateUserDTO>, UpdateUserDTOValidation>();
builder.Services.AddScoped<IValidator<CreateRoleDTO>, CreateRoleDTOValidation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.Run();