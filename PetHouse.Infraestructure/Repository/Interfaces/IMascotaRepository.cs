using PetHouse.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.Infraestructure.Repository.Interfaces
{
    public interface IMascotaRepository
    {
        Task<IEnumerable<Mascotas>> GetAllAsync();

        Task<Mascotas?> GetByIdAsync(int id);
        Task<Mascotas> AddAsync(Mascotas mascota);
        Task<Mascotas> UpdateAsync(Mascotas mascota);

        Task<bool> DeleteAsync(int id);
    }
}
