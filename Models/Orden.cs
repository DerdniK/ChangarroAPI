using Amazon.DynamoDBv2.DataModel;

namespace changarroAPI.Models
{

[DynamoDBTable("Ordenes")]
    public class Orden
    {
        [DynamoDBHashKey("id")]
        public string? Id { get; set; }

        // Mapeo exacto a lo que envía/recibe el JavaScript
        [DynamoDBProperty("cliente")]
        public string? Cliente { get; set; }

        [DynamoDBProperty("email")]
        public string? Email { get; set; }

        [DynamoDBProperty("telefono")]
        public string? Telefono { get; set; }

        [DynamoDBProperty("fecha")]
        public string? Fecha { get; set; }

        [DynamoDBProperty("total")]
        public decimal Total { get; set; }

        [DynamoDBProperty("completada")]
        public bool Completada { get; set; }
        
        [DynamoDBProperty("fechaCompletada")]
        public string? FechaCompletada { get; set; }

        [DynamoDBProperty("productos")]
        public List<OrdenProducto> Productos { get; set; } = new List<OrdenProducto>();
    }

    public class OrdenProducto
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}