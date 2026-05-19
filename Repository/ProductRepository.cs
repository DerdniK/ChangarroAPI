using Dtos;
using changarroAPI.Models;
using MongoDB.Driver;

namespace changarroAPI.Repository // El encargado de ir a la base de datos, traer la info y devolverla a los servicios
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Producto> _collection;
        public ProductRepository(IMongoClient client)
        {
            var database = client.GetDatabase("ChangarroDB");
            _collection = database.GetCollection<Producto>("Productos");
        }

        public async Task<List<Producto>> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            return await _collection.Find(_ => true)
                                    .ToListAsync(cancellationToken);
        }

        public async Task<Producto> GetProductByIdAsync(string id, CancellationToken cancellationToken)
        {
            // Filtramos en Mongo por el campo Id
            return await _collection.Find(p => p.Id == id)
                                    .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Producto> CreateProductAsync(Producto producto, CancellationToken cancellationToken)
        {
            await _collection.InsertOneAsync(producto, cancellationToken: cancellationToken);
            return producto;
        }
    }
}