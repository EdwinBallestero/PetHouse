using PetHouse.Infraestructure.Models;

namespace PetHouse.Infraestructure.Repository.Interfaces;

public interface IEmpleadosRepository
{ 
    Task<Empleados?> GetByUsuarioIdAsync(int usuarioId);

    Task<IEnumerable<Empleados>> GetBySucursalIdAsync(int sucursalId);
}   