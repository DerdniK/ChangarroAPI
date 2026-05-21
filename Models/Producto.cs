using Amazon.DynamoDBv2.DataModel;

namespace changarroAPI.Models
{
    [DynamoDBTable("Productos")]
    public class Producto
    {
        [DynamoDBHashKey("id")]
        public string? Id { get; set; } // Partition Key

        [DynamoDBProperty("Title")]
        public string? Title { get; set; } // "Black clover"

        [DynamoDBProperty("ImageUrl")]
        public string? ImageUrl { get; set; } // "https://example.com/product-image.jpg"

        [DynamoDBProperty("Type")]
        public string? Type { get; set; } // "Pin", "Sticker", "Póster"

        [DynamoDBProperty("Category")]
        public string? Category { get; set; } // "Anime", "Videojuegos", "Peliculas"

        [DynamoDBProperty("Price")]
        public decimal Price { get; set; } // 19.99

        [DynamoDBProperty("Stock")]
        public int Stock { get; set; } // 10 
    }
}