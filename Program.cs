using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseRouting();

var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();
#pragma warning disable CS8604 // Possible null reference argument.
app.UseCors(builder => 
    builder.WithOrigins(allowedOrigins)
           .AllowAnyHeader()
           .AllowAnyMethod());
#pragma warning restore CS8604 // Possible null reference argument.

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});

app.Run();
