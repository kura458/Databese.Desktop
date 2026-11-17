
using Microsoft.AspNetCore.Mvc;
using SE4.API.DTOs;
using SE4.API.Interfaces;

namespace SE4.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // CREATE PRODUCT
        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(
            [FromBody] ProductDto dto)
        {
            var result = await _productService.CreateProductAsync(dto);

            return Ok(result);
        }

        // GET ALL PRODUCTS
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();

            return Ok(products);
        }

        // GET PRODUCT BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound("Product not found.");
            }

            return Ok(product);
        }

        // UPDATE PRODUCT
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(
            int id, [FromBody] ProductDto dto)
        {
            var result = await _productService.UpdateProductAsync(id, dto);

            if (result == null)
            {
                return NotFound("Product not found.");
            }

            return Ok(result);
        }

        // DELETE PRODUCT
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleted = await _productService.DeleteProductAsync(id);

            if (!deleted)
            {
                return NotFound("Product not found.");
            }

            return Ok("Product deleted successfully.");
        }
    }
}
