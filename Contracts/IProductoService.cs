using changarroAPI.Models;
using Dtos;

namespace changarroAPI.Services
{
    public interface IProductoService
    {
        Task<List<ProductResponseDto>> GetAllProducts(CancellationToken cancellationToken);
        Task<ProductResponseDto?> GetProductById(string id, CancellationToken cancellationToken);
        Task<CreateProductResponseDto> CreateProduct(Producto producto, CancellationToken cancellationToken);
        // Task<ProductResponseDto> UpdateProduct(string id, Producto producto, CancellationToken cancellationToken);
        // Task<DeleteProductoDto> DeleteProduct(string id, CancellationToken cancellationToken);
    }
}
