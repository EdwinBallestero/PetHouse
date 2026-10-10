
using System.Net.Http.Json;
using PetHouse.Application.DTOs;

namespace PetHouse.web.Services
{
    public class UsuarioApiService
    {
        private readonly HttpClient _httpClient;

        public UsuarioApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UsuariosDTO>> GetAllAsync()
        {
            var usuarios = await _httpClient
                .GetFromJsonAsync<List<UsuariosDTO>>("api/Usuarios");

            return usuarios ?? new List<UsuariosDTO>();
        }

        public async Task<UsuariosDTO?> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/Usuarios/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<UsuariosDTO>();
        }
    }
}
