using changarroAPI.Services;
using MongoDB.Driver;
using Scalar.AspNetCore;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IMongoClient>(sp => 
{
    // Usa tu cadena de conexión (la que sacas de Compass o Atlas)
    var connectionString = "mongodb://localhost:27017"; 
    return new MongoClient(connectionString);
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddScoped<IProductoService, ProductoService>();

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

// app.UseHttpsRedirection();

app.Run();
