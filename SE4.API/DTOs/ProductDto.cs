
namespace SE4.API.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string ProductName { get; set; } = "";

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
