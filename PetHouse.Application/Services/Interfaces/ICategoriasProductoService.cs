
using PetHouse.Application.DTOs;

namespace PetHouse.Application.Services.Interfaces
{
    public interface ICategoriasProductoService
    {
        Task<IEnumerable<CategoriasProductoDTO>> GetAllAsync();

        Task<CategoriasProductoDTO?> GetByIdAsync(int id);

        Task<CategoriasProductoDTO> InsertAsync(
            CategoriasProductoDTO dto);

        Task<CategoriasProductoDTO?> UpdateAsync(
            CategoriasProductoDTO dto);

        Task<bool> DeleteAsync(int id);
    }
}
