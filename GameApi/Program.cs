using GameApi.Models;
using GameApi.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<PlayerDatabaseSettings>(
    builder.Configuration.GetSection(nameof(PlayerDatabaseSettings)));

builder.Services.AddSingleton<IPlayerDatabaseSettings>
    (sp => sp.GetRequiredService<IOptions<PlayerDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(
    s => new MongoClient(builder.Configuration.GetValue<string>("PlayerDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IPlayerService, PlayerService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
