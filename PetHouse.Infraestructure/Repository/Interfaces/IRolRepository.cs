using PetHouse.Infraestructure.Models;

namespace PetHouse.Infraestructure.Repository.Interfaces
{
    public interface IRolRepository
    {
        Task<Roles?> GetByIdAsync(int id);
        Task<ICollection<Roles>> GetAllAsync();
        Task<Roles> InsertAsync(Roles rol);
        Task<Roles> UpdateAsync(Roles rol);
        Task<bool> DeleteAsync(int id);
    }
}