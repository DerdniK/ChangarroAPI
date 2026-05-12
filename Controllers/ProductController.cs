using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductoService _productoService;
        public ProductsController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        // localhost:5352/api/v1/products/{id} --> GET api/v1/products/{id}
        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<IActionResult> GetProductById(string id, CancellationToken cancellationToken)
        {
            var product = await _productoService.GetProductById(id, cancellationToken);
            return product == null ? NotFound() : Ok(product);
        }
    }
}