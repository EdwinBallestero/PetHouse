using PetHouse.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.Infraestructure.Repository.Interfaces
{
    public interface IRazaRepository
    {
        Task<IEnumerable<Razas>> GetAllAsync();
        Task<Razas?> GetByIdAsync(int id);
        Task<Razas> AddAsync(Razas raza);
        Task<Razas> UpdateAsync(Razas raza);

        Task<bool> DeleteAsync(int id);
    }
}
