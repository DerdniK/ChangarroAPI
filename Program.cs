using changarroAPI.Services;
using MongoDB.Driver;
using changarroAPI.Repository;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IMongoClient>(sp => 
{
    // Usa tu cadena de conexión (la que sacas de Compass o Atlas)
    var connectionString = "mongodb+srv://admin:MuT8FgY7rj4pmoi2@changarrocluster.w9pecj0.mongodb.net/"; 
    return new MongoClient(connectionString);
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

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
