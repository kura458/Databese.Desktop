
using SE4.API.DTOs;

namespace SE4.API.Interfaces
{
    public interface IProductService
    {
        // Create a new product
        Task<ProductDto> CreateProductAsync(ProductDto dto);

        // Get all products
        Task<List<ProductDto>> GetAllProductsAsync();

        // Get one product by ID
        Task<ProductDto?> GetProductByIdAsync(int id);

        // Update an existing product
        Task<ProductDto?> UpdateProductAsync(int id, ProductDto dto);

        // Delete a product
        Task<bool> DeleteProductAsync(int id);
    }
}
