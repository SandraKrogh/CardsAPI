using BackendAPI.Services;
using Microsoft.EntityFrameworkCore;
using BackendAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<MongoService>();
builder.Services.AddSingleton<CardService>();
builder.Services.AddSingleton<ClassService>();
builder.Services.AddSingleton<RarityService>();
builder.Services.AddSingleton<SetService>();
builder.Services.AddSingleton<TypeService>();


//var mongoService = new MongoService();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<CardsDatabaseSettings>(
    builder.Configuration.GetSection("CardsDatabase"));

//var cardsDatabaseSettings = new CardsDatabaseSettings();
//var mongoService = new MongoService(cardsDatabaseSettings);

builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

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
