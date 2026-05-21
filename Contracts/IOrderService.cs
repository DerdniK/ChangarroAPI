namespace changarroAPI.Contracts
{
    public interface IOrderService
    {
        Task<List<Models.Orden>> GetAllOrdersAsync();
        Task<Models.Orden> GetOrderByIdAsync(string id);
        Task CreateOrderAsync(Models.Orden orden);
        Task UpdateOrderAsync(Models.Orden orden);
        Task DeleteOrderAsync(string id);
        Task<List<Models.Orden>> GetOrdersByUserAsync(string username);
    }
}