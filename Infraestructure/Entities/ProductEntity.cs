namespace changarroAPI.Infraestructure.Entities
{
    public class ProductEntity
    {
        public string? Id { get; set; } // 1
        public string? Title { get; set; } // "Black clover"
        public string? ImageId { get; set; } // 1
        public string? Type { get; set; } // "Pin", "Sticker", "Póster"
        public string? Category { get; set; } // "Anime", "Videojuegos", "Peliculas"
        public decimal Price { get; set; } // 19.99
        public int Stock { get; set; } // 10 
    }
}