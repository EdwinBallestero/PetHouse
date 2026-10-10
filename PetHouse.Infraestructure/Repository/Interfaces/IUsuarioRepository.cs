using PetHouse.Infraestructure.Models;

namespace PetHouse.Infraestructure.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<ICollection<Usuarios>> GetAllAsync();
        Task<Usuarios?> GetByIdAsync(int id);
        Task<Usuarios?> GetByCorreoAsync(string correo);
        Task<Usuarios?> GetByCedulaAsync(string cedula);
        Task<Usuarios> InsertAsync(Usuarios usuario);
        Task<Usuarios> UpdateAsync(Usuarios usuario);
        Task<bool> DeleteAsync(int id);
    }
}