using Dtos;
using changarroAPI.Models;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;

namespace changarroAPI.Repository // El encargado de ir a la base de datos, traer la info y devolverla a los servicios
{
    public class ProductRepository : IProductRepository
    {
        private readonly IAmazonDynamoDB _dynamoClient;
        private const string TableName = "Productos";

        public ProductRepository(IAmazonDynamoDB dynamoClient)
        {
            _dynamoClient = dynamoClient;
        }

        public async Task<List<Producto>> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            using var context = new DynamoDBContext(_dynamoClient);
            var products = await context.ScanAsync<Producto>(new List<ScanCondition>()).GetRemainingAsync(cancellationToken);
            return products.ToList();
        }

        public async Task<Producto?> GetProductByIdAsync(string id, CancellationToken cancellationToken)
        {
            using var context = new DynamoDBContext(_dynamoClient);
            var product = await context.LoadAsync<Producto>(id, cancellationToken);
            return product;
        }

        public async Task<Producto> CreateProductAsync(Producto producto, CancellationToken cancellationToken)
        {
            // Generar ID si no existe
            if (string.IsNullOrEmpty(producto.Id))
            {
                producto.Id = Guid.NewGuid().ToString();
            }

            using var context = new DynamoDBContext(_dynamoClient);
            await context.SaveAsync(producto, cancellationToken);
            return producto;
        }

        public async Task UpdateProductAsync(Producto producto, CancellationToken cancellationToken)
        {
            using var context = new DynamoDBContext(_dynamoClient);
            await context.SaveAsync(producto, cancellationToken); // SaveAsync también actualiza
        }
    }
}