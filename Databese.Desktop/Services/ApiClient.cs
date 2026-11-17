
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Databese.Desktop.Models;

namespace Databese.Desktop.Services
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7213/")
            };
        }

        // REGISTER USER
        public async Task<AuthResponse?> RegisterAsync(
            string username, string password)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/Users/register",
                new { username, password });

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<AuthResponse>();
        }

        // LOGIN USER
        public async Task<AuthResponse?> LoginAsync(
            string username, string password)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/Users/login",
                new { username, password });

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<AuthResponse>();
        }

        // CHANGE PASSWORD
        public async Task<AuthResponse?> ChangePasswordAsync(
            string username, string oldPassword, string newPassword)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/Users/change-password",
                new { username, oldPassword, newPassword });

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<AuthResponse>();
        }

        // GET ALL PRODUCTS
        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var response = await _httpClient.GetAsync("api/Products");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<ProductDto>>()
                ?? new List<ProductDto>();
        }

        // GET PRODUCT BY ID
        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(
                $"api/Products/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ProductDto>();
        }

        // CREATE PRODUCT
        public async Task<ProductDto?> CreateProductAsync(ProductDto product)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/Products", product);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ProductDto>();
        }

        // UPDATE PRODUCT
        public async Task<ProductDto?> UpdateProductAsync(
            int id, ProductDto product)
        {
            var response = await _httpClient.PutAsJsonAsync(
                $"api/Products/{id}", product);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ProductDto>();
        }

        // DELETE PRODUCT
        public async Task<bool> DeleteProductAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(
                $"api/Products/{id}");

            response.EnsureSuccessStatusCode();

            return true;
        }
    }
}
