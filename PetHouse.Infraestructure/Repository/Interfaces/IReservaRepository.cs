using PetHouse.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.Infraestructure.Repository.Interfaces
{
    public interface IReservaRepository
    {
        Task<IEnumerable<Reservas>> GetAllAsync();

        Task<Reservas?> GetByIdAsync(int id);
        Task<Reservas> AddAsync(Reservas reserva);
        Task<Reservas> UpdateAsync(Reservas reserva);

        Task<bool> DeleteAsync(int id);
    }
}
