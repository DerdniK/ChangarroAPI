using changarroAPI.Contracts;
using changarroAPI.Repository;

namespace changarroAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Models.Orden>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllOrdersAsync();
        }

        public async Task<Models.Orden> GetOrderByIdAsync(string id)
        {
            return await _orderRepository.GetOrderByIdAsync(id);
        }

        public async Task CreateOrderAsync(Models.Orden orden)
        {
            await _orderRepository.CreateOrderAsync(orden);
        }

        public async Task UpdateOrderAsync(Models.Orden orden)
        {
            await _orderRepository.UpdateOrderAsync(orden);
        }

        public async Task DeleteOrderAsync(string id)
        {
            await _orderRepository.DeleteOrderAsync(id);
        }
    }
}