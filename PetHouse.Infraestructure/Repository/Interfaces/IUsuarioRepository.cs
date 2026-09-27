using PetHouse.Infraestructure.Models;

namespace PetHouse.Infrastructure.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuarios>> GetAllAsync();

        Task<Usuarios?> GetByIdAsync(int id);

        Task<Usuarios> AddAsync(Usuarios usuario);

        Task<Usuarios> UpdateAsync(Usuarios usuario);

        Task<bool> DeleteAsync(int id);
    }
}