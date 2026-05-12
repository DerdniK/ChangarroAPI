namespace Dtos
{
    public class ProductResponseDto
    {
        public string? Id { get; set; } // "HG1267BHJF0KL"
        public string? Title { get; set; } // "Black clover"
        public string? Type { get; set; } // "Pin", "Sticker", "Póster"
        public string? Category { get; set; } // "Anime", "Videojuegos", "Peliculas"
        public decimal Price { get; set; } // 80.00
        public int Stock { get; set; } // 10
    }
}