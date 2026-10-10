
using System.Net.Http.Json;
using PetHouse.Application.DTOs;

namespace PetHouse.web.Services
{
    public class ProductoApiService
    {
        private readonly HttpClient _httpClient;

        public ProductoApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductosDTO>> GetAllAsync()
        {
            var productos =
                await _httpClient.GetFromJsonAsync<List<ProductosDTO>>(
                    "api/Productos");

            return productos ?? new List<ProductosDTO>();
        }

        public async Task<ProductosDTO?> GetByIdAsync(int id)
        {
            var response =
                await _httpClient.GetAsync($"api/Productos/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content
                .ReadFromJsonAsync<ProductosDTO>();
        }

        public async Task<ProductosDTO?> CreateAsync(
            ProductosDTO producto)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/Productos", producto);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content
                .ReadFromJsonAsync<ProductosDTO>();
        }

        public async Task<bool> UpdateAsync(
            int id, ProductosDTO producto)
        {
            var response = await _httpClient.PutAsJsonAsync(
                $"api/Productos/{id}", producto);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response =
                await _httpClient.DeleteAsync($"api/Productos/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
