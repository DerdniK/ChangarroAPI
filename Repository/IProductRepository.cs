using Dtos;
using changarroAPI.Models;

namespace changarroAPI.Repository
{
    public interface IProductRepository
    {
        Task<List<Producto>> GetAllProductsAsync(CancellationToken cancellationToken);
        Task<Producto> GetProductByIdAsync(string id, CancellationToken cancellationToken);
        Task<Producto> CreateProductAsync(Producto producto, CancellationToken cancellationToken);
    }
}