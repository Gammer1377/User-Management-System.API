using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using System.Text;
using User_Management_System.Data;

var builder = WebApplication.CreateBuilder(args);
string template = "{Timestamp:yyyy/MM/dd - HH:mm:ss zzz} [{Level:u3}] {Message:lj} {NewLine} {Exception}";
string path = "SeriLog/log.txt";

#region SinkToConsole

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(theme: AnsiConsoleTheme.Code)
    .CreateLogger();

#endregion

#region SinkToFile

//Log.Logger = new LoggerConfiguration()
//    .WriteTo.File(path, rollingInterval: RollingInterval.Day, fileSizeLimitBytes: 12000, rollOnFileSizeLimit: true, retainedFileCountLimit: 10,outputTemplate:template)
//    .CreateLogger();

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

builder.Services.ConfigurePersistenceService(builder.Configuration);
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