using MyUniversityAPIGateway.Application;
using MyUniversityAPIGateway.Domain.Repository;
using MyUniversityAPIGateway.Infrastructure.ExternalServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

// Register HttpClient for external services
builder.Services.AddHttpClient();

// Register application services
builder.Services.AddScoped<ICourseRepository, HttpCourseRepository>();
builder.Services.AddScoped<CourseService>();

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.MapOpenApi("/openapi/v1.json");
}

app.UseHttpsRedirection();
app.Run();
