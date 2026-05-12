namespace Dtos
{
    public class CreateProductDto
    {
        public string? Id { get; set; } // "HG1267BHJF0KL"
        public string? Title { get; set; } // "Black clover"
        public string? Type { get; set; } // "Pin", "Sticker", "Póster"
        public decimal Price { get; set; } // 80.00
    }
}