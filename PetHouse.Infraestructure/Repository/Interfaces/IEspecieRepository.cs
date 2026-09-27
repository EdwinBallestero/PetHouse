using PetHouse.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.Infraestructure.Repository.Interfaces
{
    public interface IEspecieRepository
    {
        Task<IEnumerable<Especies>> GetAllAsync();

        Task<Especies?> GetByIdAsync(int id);
        Task<Especies> AddAsync(Especies especie);
        Task<Especies> UpdateAsync(Especies especie);

        Task<bool> DeleteAsync(int id);
    }
}
