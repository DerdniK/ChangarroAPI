using changarroAPI.Services;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using changarroAPI.Repository;
using Scalar.AspNetCore;
using Amazon;
using changarroAPI.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IAmazonDynamoDB>(sp => 
{
    // Configurar cliente DynamoDB con credenciales de AWS
    return new AmazonDynamoDBClient(RegionEndpoint.USEast1);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseCors("PermitirTodo");
app.MapControllers();

// app.UseHttpsRedirection();

app.Run();
