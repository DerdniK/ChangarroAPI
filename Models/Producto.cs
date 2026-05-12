using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    public class Producto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } // 1
        [BsonElement("Nombre")]
        public string? Title { get; set; } // "Black clover"
        [BsonElement("IdImagen")]
        public string? ImageId { get; set; } // 1
        [BsonElement("Tipo")]
        public string? Type { get; set; } // "Pin", "Sticker", "Póster"
        [BsonElement("Categoria")]
        public string? Category { get; set; } // "Anime", "Videojuegos", "Peliculas"
        [BsonElement("Precio")]
        public decimal Price { get; set; } // 19.99
        [BsonElement("Stock")]
        public int Stock { get; set; } // 10 
    }
}