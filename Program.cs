using System.Configuration;
using AquaBrainAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        In = ParameterLocation.Header,
        Description = "Basic Authorization header using the Bearer scheme."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "basic"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddScoped<IKlantService, KlantService>();
builder.Services.AddScoped<IWoningService, WoningService>();
builder.Services.AddScoped<IWatertonService, WatertonService>();
builder.Services.AddScoped<ISensorService, SensorService>();
builder.Services.AddScoped<IValveService, ValveService>();
string MySqlServer = Environment.GetEnvironmentVariable("MYSQL_HOST") ?? "";
string MySqlPort = Environment.GetEnvironmentVariable("MYSQL_PORT") ?? "3306";
string MySqlDatabase = Environment.GetEnvironmentVariable("MYSQL_DATABASE") ?? "";
string MySqlUser = Environment.GetEnvironmentVariable("MYSQL_USER") ?? "";
string MySqlPassword = Environment.GetEnvironmentVariable("MYSQL_PASSWORD") ?? "";

string MySqlConnectionString = $"server={MySqlServer};port={MySqlPort};database={MySqlDatabase};user={MySqlUser};password={MySqlPassword}";

builder.Services.AddDbContext<DevelopmentContext>(options =>
    //options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    options.UseMySql(MySqlConnectionString,
    ServerVersion.Parse("8.2.0-mysql")));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    //app.UseSwagger();
    //app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
