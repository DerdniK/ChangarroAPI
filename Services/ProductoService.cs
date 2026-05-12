using Dtos;
using Models;
using MongoDB.Driver;
using Services;

namespace changarroAPI.Services // TODA LA LOGICA DE NEGOCIOS
{
    public class ProductoService : IProductoService
    {
        IMongoClient _client;
        public ProductoService(IMongoClient client)
        {
            _client = client;
        }
    
    public async Task<ProductResponseDto?> GetProductById(string id, CancellationToken cancellationToken)
    {
        var database = _client.GetDatabase("chagarro");
        var collection = database.GetCollection<Models.Producto>("productos");
        var filter = Builders<Models.Producto>.Filter.Eq(p => p.Id, id);
        var producto = await collection.Find(filter).FirstOrDefaultAsync(cancellationToken);
        if (producto == null)
            return null;
        
        return new ProductResponseDto
        {
            Id = producto.Id,
            Title = producto.Title,
            Type = producto.Type,
            Category = producto.Category,
            Price = producto.Price,
            Stock = producto.Stock
        };

    }

    public async Task<CreateProductResponseDto> CreateProduct(Producto producto, CancellationToken cancellationToken)
    {
        var database = _client.GetDatabase("chagarro");
        var collection = database.GetCollection<Models.Producto>("productos");
        await collection.InsertOneAsync(producto, cancellationToken: cancellationToken);
        return new CreateProductResponseDto
        {
            Id = producto.Id,
            Title = producto.Title,
        };
    }
}
}