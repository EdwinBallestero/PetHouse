
using PetHouse.Application.DTOs;

namespace PetHouse.Application.Services.Interfaces
{
    public interface IMascotasService
    {
        Task<IEnumerable<MascotasDTO>> GetAllAsync();

        Task<MascotasDTO?> GetByIdAsync(int id);

        Task<MascotasDTO> InsertAsync(MascotasDTO dto);

        Task<MascotasDTO?> UpdateAsync(MascotasDTO dto);

        Task<bool> DeleteAsync(int id);
    }
}
