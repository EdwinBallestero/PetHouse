using PetHouse.Application.DTOs;
using PetHouse.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.Application.Services.Interfaces
{
    public interface IUsuariosService
    {
        Task<ICollection<UsuariosDTO>> GetAllAsync();

        Task<UsuariosDTO?> GetByIdAsync(int id);

        Task<UsuariosDTO> InsertAsync(Usuarios usuario);

        Task<UsuariosDTO> UpdateAsync(Usuarios usuario);

        Task<bool> DeleteAsync(int id);
    }
}
