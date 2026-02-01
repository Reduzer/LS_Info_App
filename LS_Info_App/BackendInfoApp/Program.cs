using BackendInfoApp.DB;
using BackendInfoApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<InfoAppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("InfoAppDB")));

builder.Services.AddHostedService<WeatherUpdateService>();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();