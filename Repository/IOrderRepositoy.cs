namespace changarroAPI.Repository
{
    public interface IOrderRepository
    {
        Task<List<Models.Orden>> GetAllOrdersAsync();
        Task<Models.Orden> GetOrderByIdAsync(string id);
        Task CreateOrderAsync(Models.Orden orden);
        Task UpdateOrderAsync(Models.Orden orden);
        Task DeleteOrderAsync(string id);
    }
}