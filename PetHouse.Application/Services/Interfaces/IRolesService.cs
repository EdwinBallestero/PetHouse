using PetHouse.Application.DTOs;

namespace PetHouse.Application.Services.Interfaces
{
    public interface IRolesService
    {
        Task<RolesDTO?> GetByIdAsync(int id);
        Task<ICollection<RolesDTO>> GetAllAsync();
        Task<RolesDTO> InsertAsync(RolesDTO dto);
        Task<RolesDTO?> UpdateAsync(RolesDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}