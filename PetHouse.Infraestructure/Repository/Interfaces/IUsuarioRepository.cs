using PetHouse.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PetHouse.Infraestructure.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<ICollection<Usuarios>> GetAllAsync();

        Task<Usuarios?> GetByIdAsync(int id);

        Task<Usuarios> InsertAsync(Usuarios usuario);

        Task<Usuarios> UpdateAsync(Usuarios usuario);

        Task<bool> DeleteAsync(int id);
    }
}