using Dtos;
using changarroAPI.Models;

namespace changarroAPI.Mappers
{
    public static class ProductoMapper
    {
        public static ProductResponseDto ToProductResponseDto(this Producto producto)
        {
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

        public static CreateProductResponseDto ToCreateProductResponseDto(this Producto producto)
        {
            return new CreateProductResponseDto
            {
                Id = producto.Id,
                Title = producto.Title,
            };
        }
    }
}