
using PetHouse.Infraestructure.Models;

namespace PetHouse.Infraestructure.Repositories.Interfaces
{
    public interface IMascotasRepository
    {
        Task<IEnumerable<Mascotas>> GetAllAsync();

        Task<Mascotas?> GetByIdAsync(int id);

        Task<Mascotas> InsertAsync(Mascotas mascota);

        Task<Mascotas?> UpdateAsync(Mascotas mascota);

        Task<bool> DeleteAsync(int id);
    }
}
