

using Microsoft.EntityFrameworkCore;
using PetHouse.Infraestructure.Data;
using PetHouse.Infraestructure.Models;
using PetHouse.Infraestructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PetHouse.Infraestructure.Repository.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PetHouseContext _context;

        public UsuarioRepository(PetHouseContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Usuarios>> GetAllAsync()
        {
            //Select * from Usuarios
            var collection = await _context.Set<Usuarios>().ToListAsync();
            return collection;
        }

        public async Task<Usuarios?> GetByIdAsync(int id)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.UsuarioId == id);
        }

        public async Task<Usuarios> InsertAsync(Usuarios usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuarios> UpdateAsync(Usuarios usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await GetByIdAsync(id);

            if (usuario == null)
                return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
