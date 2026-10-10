using PetHouse.Infraestructure.Models;

namespace PetHouse.Infraestructure.Repositories.Interfaces
{
    public interface IProductosRepository
    {
        Task<IEnumerable<Productos>> GetAllAsync();

        Task<Productos?> GetByIdAsync(int id);

        Task<Productos> InsertAsync(Productos producto);

        Task<Productos?> UpdateAsync(Productos producto);

        Task<bool> DeleteAsync(int id);
    }
}
