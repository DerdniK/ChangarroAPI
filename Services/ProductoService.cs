using Dtos;
using changarroAPI.Models;
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
            if (!string.IsNullOrEmpty(producto.Title))
            {
                // Sanitización opcional para entornos web (reemplaza espacios por guiones o formatos limpios)
                // Si tus archivos en GitHub se llaman exactamente igual que el título (ej. "Evangelion.png"), 
                // puedes usar directamente: producto.Title.Trim()
                string nombreArchivo = producto.Title.Trim();

                // Construcción automática de la URL
                producto.ImageUrl = $"https://changarroweb.s3.us-east-1.amazonaws.com/source/img/{nombreArchivo}.png";
            }

            var created = await _productRepository.CreateProductAsync(producto, cancellationToken);
            return Mappers.ProductoMapper.ToCreateProductResponseDto(created);
        }

        public async Task UpdateProduct(string id, Producto producto, CancellationToken cancellationToken)
        {
            producto.Id = id;
            await _productRepository.UpdateProductAsync(producto, cancellationToken);
        }
    }
}