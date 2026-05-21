using Microsoft.AspNetCore.Mvc;
using changarroAPI.Models;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace changarroAPI.Controllers
{
    [ApiController]
    [Route("api/v1/usuarios")] // Esto crea la ruta: api/v1/Usuarios
    public class UsersController : ControllerBase
    {
        private readonly IAmazonDynamoDB _dynamoClient;

        public UsersController(IAmazonDynamoDB dynamoClient)
        {
            _dynamoClient = dynamoClient;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            using var context = new DynamoDBContext(_dynamoClient);
            var user = await context.LoadAsync<Usuario>(request.Usuario);

            if (user == null || user.Password != request.Password)
            {
                return Unauthorized(new { mensaje = "Usuario o contraseña incorrectos" });
            }

            return Ok(new { 
                usuario = user.Username, 
                nombre = user.Nombre, 
                esAdmin = user.EsAdmin 
            });
        }

        [HttpPost("registro")]
        public async Task<IActionResult> RegistrarUsuario([FromBody] Usuario nuevoUsuario)
        {
            using var context = new DynamoDBContext(_dynamoClient);
            var existe = await context.LoadAsync<Usuario>(nuevoUsuario.Username);
            
            if (existe != null) return BadRequest(new { mensaje = "El usuario ya existe" });
            
            await context.SaveAsync(nuevoUsuario);
            return Ok(nuevoUsuario);
        }
    }
}