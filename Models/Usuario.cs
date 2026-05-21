using Amazon.DynamoDBv2.DataModel;

namespace changarroAPI.Models
{
    [DynamoDBTable("Usuarios")] // Asegúrate de que tu tabla en AWS se llame exactamente así
    public class Usuario
    {
        [DynamoDBHashKey("usuario")] 
        public string? Username { get; set; }

        [DynamoDBProperty("password")]
        public string? Password { get; set; }

        [DynamoDBProperty("nombre")]
        public string? Nombre { get; set; }

        [DynamoDBProperty("esAdmin")]
        public bool EsAdmin { get; set; }
    }

    // Molde auxiliar para recibir los datos de inicio de sesión
    public class LoginRequest 
    {
        public string? Usuario { get; set; }
        public string? Password { get; set; }
    }
}