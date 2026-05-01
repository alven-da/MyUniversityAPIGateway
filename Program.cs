using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Infrastructure.ExternalServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyUniversityAPIGateway.Application;
using MyUniversityAPIGateway.Data.Mock;
using MyUniversityAPIGateway.Domain.Repository;
using MyUniversityAPIGateway.Infrastructure.ExternalServices;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment;

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
    
    // Only enable this debugger on non-production setup
    if (env.IsProduction() == false) {
        options.Events = new JwtBearerEvents {
            OnAuthenticationFailed = context =>
            {
                context.Response.Headers.Add("Token-Error", context.Exception.Message);
                return Task.CompletedTask;
            }
        };   
    }

    options.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddDbContext<UniversityDbContext>(options =>
    options.UseInMemoryDatabase("UniversityDb"));

// Register Repositories
builder.Services.AddScoped<ICourseRepository, CourseDbContextRepository>();
builder.Services.AddScoped<IStudentRepository, StudentDbContextRepository>();

// Register Services
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<StudentService>();

builder.Services.AddControllers();

var app = builder.Build();

// Seed the data only in Development
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<UniversityDbContext>();
        DbInitializer.Seed(context);
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.MapOpenApi("/openapi/v1.json");
}

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();
app.UseHttpsRedirection();
app.Run();
