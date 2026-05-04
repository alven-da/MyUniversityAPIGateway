using DotNetEnv;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Infrastructure.ExternalServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyUniversityAPIGateway.Application;
using MyUniversityAPIGateway.Data.Mock;
using MyUniversityAPIGateway.Domain.Repository;

// Load the .env file
Env.Load();
var builder = WebApplication.CreateBuilder(args);

// Ensure .env is picked up by the builder
builder.Configuration.AddEnvironmentVariables();

var isProduction = Environment.GetEnvironmentVariable("ENVIRONMENT") == "Production";

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Register HttpClient for external services
builder.Services.AddHttpClient();

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options => {
    string? jwtKey = Environment.GetEnvironmentVariable("JWT_KEY") ?? "";
    string? jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? "";
    string? jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? "";
    
    // Only enable this debugger on non-production setup
    if (!isProduction) {
        options.Events = new JwtBearerEvents {
            OnAuthenticationFailed = context =>
            {
                context.Response.Headers.Append("Token-Error", context.Exception.Message);
                return Task.CompletedTask;
            }
        };   
    }

    options.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

builder.Services.AddDbContext<UniversityDbContext>(options =>
    options.UseInMemoryDatabase("UniversityDb"));

// Register Repositories
builder.Services.AddScoped<ICourseRepository, CourseDbContextRepository>();
builder.Services.AddScoped<IStudentRepository, StudentDbContextRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectDbContextRepository>();

// Register Services
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<SubjectService>();

builder.Services.AddControllers();

var app = builder.Build();

// Seed the data only in Development
if (!isProduction) {
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<UniversityDbContext>();
        DbInitializer.Seed(context);
    }
}

// Configure the HTTP request pipeline.
if (!isProduction) {
    app.MapOpenApi("/openapi/v1.json");
}

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();
app.UseHttpsRedirection();
app.Run();
