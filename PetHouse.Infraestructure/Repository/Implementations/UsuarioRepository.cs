

using Microsoft.EntityFrameworkCore;
using PetHouse.Infraestructure.Data;
using PetHouse.Infraestructure.Models;
using PetHouse.Infrastructure.Repository.Interfaces;

namespace PetHouse.Infrastructure.Repository.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PetHouseContext _context;

        public UsuarioRepository(PetHouseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuarios>> GetAllAsync()
        {
            return await _context.Usuarios
                .ToListAsync();
        }

        public async Task<Usuarios?> GetByIdAsync(int id)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.UsuarioId == id);
        }

        public async Task<Usuarios> AddAsync(Usuarios usuario)
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
