using Dtos;
using changarroAPI.Models;
using MongoDB.Driver;
using changarroAPI.Repository;

namespace changarroAPI.Services // TODA LA LOGICA DE NEGOCIOS
{
    public class ProductoService : IProductoService
    {
        private readonly IProductRepository _productRepository;
        public ProductoService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
    
        public async Task<List<ProductResponseDto>> GetAllProducts(CancellationToken cancellationToken)
        {
            var productos = await _productRepository.GetAllProductsAsync(cancellationToken);
            return productos.Select(p => Mappers.ProductoMapper.ToProductResponseDto(p)).ToList();
        }

        public async Task<ProductResponseDto?> GetProductById(string id, CancellationToken cancellationToken)
        {
            var producto = await _productRepository.GetProductByIdAsync(id, cancellationToken);
            if (producto == null)
                return null;

            return Mappers.ProductoMapper.ToProductResponseDto(producto);
        }

        public async Task<CreateProductResponseDto> CreateProduct(Producto producto, CancellationToken cancellationToken)
        {
            var created = await _productRepository.CreateProductAsync(producto, cancellationToken);
            return Mappers.ProductoMapper.ToCreateProductResponseDto(created);
        }
    }
}