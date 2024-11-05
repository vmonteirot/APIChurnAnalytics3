
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ChallengeChurnAnalytics.Data;
using ChallengeChurnAnalytics.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure the database connection using the connection string in appsettings.json
builder.Services.AddDbContext<DataContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

// Registering ExternalAuthService with dependency injection
builder.Services.AddHttpClient<ExternalAuthService>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
