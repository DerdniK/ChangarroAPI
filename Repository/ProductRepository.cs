using Dtos;
using Models;
using MongoDB.Driver;
using Services;

namespace Repository // El encargado de ir a la base de datos, traer la info y devolverla a los servicios
{
    public class ProductRepository
    {
        private readonly IProductoService _productoService;
        private readonly IMongoClient _client;

        public ProductRepository(IProductoService productoService, IMongoClient client)
        {
            _productoService = productoService;
            _client = client;
        }

        public async Task<ProductResponseDto?> GetProductByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await _productoService.GetProductById(id, cancellationToken);
        }
    }
}