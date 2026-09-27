using PetHouse.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.Infraestructure.Repository.Interfaces
{
    public interface IServicioRepository
    {
        Task<IEnumerable<Servicios>> GetAllAsync();

        Task<Servicios?> GetByIdAsync(int id);
        Task<Servicios> AddAsync(Servicios servicio);
        Task<Servicios> UpdateAsync(Servicios servicio);

        Task<bool> DeleteAsync(int id);
    }
}
