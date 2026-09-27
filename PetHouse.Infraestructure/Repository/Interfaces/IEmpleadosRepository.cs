

using PetHouse.Infraestructure.Models;

namespace PetHouse.Infrastructure.Repository.Interfaces
{
    public interface IEmpleadoRepository
    {
        Task<IEnumerable<Empleados>> GetAllAsync();

        Task<Empleados?> GetByIdAsync(int id);
        Task<Empleados> AddAsync(Empleados empleado);
        Task<Empleados> UpdateAsync(Empleados empleado);

        Task<bool> DeleteAsync(int id);
    }
}