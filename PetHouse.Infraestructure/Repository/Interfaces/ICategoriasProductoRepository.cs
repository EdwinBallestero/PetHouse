
using PetHouse.Infraestructure.Models;

namespace PetHouse.Infraestructure.Repositories.Interfaces
{
    public interface ICategoriasProductoRepository
    {
        Task<IEnumerable<CategoriasProducto>> GetAllAsync();

        Task<CategoriasProducto?> GetByIdAsync(int id);

        Task<CategoriasProducto> InsertAsync(
            CategoriasProducto categoria);

        Task<CategoriasProducto?> UpdateAsync(
            CategoriasProducto categoria);

        Task<bool> DeleteAsync(int id);
    }
}
