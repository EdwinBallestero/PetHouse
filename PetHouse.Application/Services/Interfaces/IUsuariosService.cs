using PetHouse.Application.DTOs;

namespace PetHouse.Application.Services.Interfaces
{
    public interface IUsuariosService
    {
        Task<ICollection<UsuariosDTO>> GetAllAsync();
        Task<UsuariosDTO?> GetByIdAsync(int id);
        Task<UsuariosDTO> InsertAsync(UsuariosDTO dto);
        Task<UsuariosDTO?> UpdateAsync(UsuariosDTO dto);
        Task<UsuariosDTO?> LoginAsync(UsuariosDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}