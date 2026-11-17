
using Microsoft.EntityFrameworkCore;
using SE4.API.DTOs;
using SE4.API.Interfaces;
using SE4.data.Context;
using SE4.data.Entities;

namespace SE4.API.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        // CREATE PRODUCT
        public async Task<ProductDto> CreateProductAsync(ProductDto dto)
        {
            var product = new Product
            {
                ProductName = dto.ProductName,
                Price = dto.Price,
                Quantity = dto.Quantity
            };

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            dto.Id = product.Id;

            return dto;
        }

        // GET ALL PRODUCTS
        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            return await _context.Products
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    Quantity = p.Quantity
                })
                .ToListAsync();
        }

        // GET PRODUCT BY ID
        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return null;
            }

            return new ProductDto
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                Quantity = product.Quantity
            };
        }

        // UPDATE PRODUCT
        public async Task<ProductDto?> UpdateProductAsync(
            int id, ProductDto dto)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return null;
            }

            product.ProductName = dto.ProductName;
            product.Price = dto.Price;
            product.Quantity = dto.Quantity;

            await _context.SaveChangesAsync();

            return new ProductDto
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                Quantity = product.Quantity
            };
        }

        // DELETE PRODUCT
        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
