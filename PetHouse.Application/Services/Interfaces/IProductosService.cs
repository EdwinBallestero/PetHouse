
using PetHouse.Application.DTOs;

namespace PetHouse.Application.Services.Interfaces
{
    public interface IProductosService
    {
        Task<IEnumerable<ProductosDTO>> GetAllAsync();

        Task<ProductosDTO?> GetByIdAsync(int id);

        Task<ProductosDTO> InsertAsync(ProductosDTO dto);

        Task<ProductosDTO?> UpdateAsync(ProductosDTO dto);

        Task<bool> DeleteAsync(int id);
    }
}
