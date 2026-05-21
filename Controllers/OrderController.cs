using changarroAPI.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace changarroAPI.Controllers
{
    [ApiController]
    [Route("api/v1/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.Orden>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Orden>> GetOrderById(string id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(Models.Orden orden)
        {
            await _orderService.CreateOrderAsync(orden);
            return CreatedAtAction(nameof(GetOrderById), new { id = orden.Id }, orden);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(string id, Models.Orden orden)
        {
            orden.Id = id; // Forzamos el ID para evitar el rechazo
            await _orderService.UpdateOrderAsync(orden);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(string id)
        {
            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}