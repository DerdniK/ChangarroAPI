using changarroAPI.Services;
using Microsoft.AspNetCore.Mvc;
using changarroAPI.Models;

namespace changarroAPI.Controllers
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

        // localhost:5352/api/v1/products --> GET api/v1/products (todos)
        [HttpGet]
        public async Task<IActionResult> GetAllProducts(CancellationToken cancellationToken)
        {
            var products = await _productoService.GetAllProducts(cancellationToken);
            return Ok(products);
        }

        // localhost:5352/api/v1/products/{id} --> GET api/v1/products/{id}
        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<IActionResult> GetProductById(string id, CancellationToken cancellationToken)
        {
            var product = await _productoService.GetProductById(id, cancellationToken);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Producto producto, CancellationToken cancellationToken)
        {
            var createdProduct = await _productoService.CreateProduct(producto, cancellationToken);
            return CreatedAtRoute("GetProductById", new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(string id, [FromBody] Producto producto, CancellationToken cancellationToken)
        {
            await _productoService.UpdateProduct(id, producto, cancellationToken);
            return NoContent();
        }
    }
}