using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace changarroAPI.Repository
{
    // 1. Debe ser 'class', no 'interface'
    public class OrderRepository : IOrderRepository 
    {
        private readonly IAmazonDynamoDB _dynamoClient;

        // 2. Inyectamos el cliente de Dynamo
        public OrderRepository(IAmazonDynamoDB dynamoClient)
        {
            _dynamoClient = dynamoClient;
        }

        public async Task<List<Models.Orden>> GetAllOrdersAsync()
        {
            using var context = new DynamoDBContext(_dynamoClient);
            var orders = await context.ScanAsync<Models.Orden>(new List<ScanCondition>()).GetRemainingAsync();
            return orders;
        }

        public async Task<Models.Orden> GetOrderByIdAsync(string id)
        {
            using var context = new DynamoDBContext(_dynamoClient);
            return await context.LoadAsync<Models.Orden>(id);
        }

        public async Task CreateOrderAsync(Models.Orden orden)
        {
            using var context = new DynamoDBContext(_dynamoClient);
            await context.SaveAsync(orden); // DynamoDB usa Save para insertar
        }

        public async Task UpdateOrderAsync(Models.Orden orden)
        {
            using var context = new DynamoDBContext(_dynamoClient);
            await context.SaveAsync(orden); // Y también usa Save para sobreescribir/actualizar
        }

        public async Task DeleteOrderAsync(string id)
        {
            using var context = new DynamoDBContext(_dynamoClient);
            await context.DeleteAsync<Models.Orden>(id);
        }

        public async Task<List<Models.Orden>> GetOrdersByUserAsync(string username)
        {
            using var context = new DynamoDBContext(_dynamoClient);
            var conditions = new List<ScanCondition>
            {
                new ScanCondition("UsuarioId", Amazon.DynamoDBv2.DocumentModel.ScanOperator.Equal, username)
            };
            return await context.ScanAsync<Models.Orden>(conditions).GetRemainingAsync();
        }
    }
}