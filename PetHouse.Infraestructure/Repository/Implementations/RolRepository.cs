using Microsoft.EntityFrameworkCore;
using PetHouse.Infraestructure.Data;
using PetHouse.Infraestructure.Models;
using PetHouse.Infraestructure.Repository.Interfaces;

namespace PetHouse.Infraestructure.Repository.Implementations
{
    public class RolRepository : IRolRepository
    {
        private readonly PetHouseContext _context;

        public RolRepository(PetHouseContext context)
        {
            _context = context;
        }

        public async Task<Roles?> GetByIdAsync(int id)
        {
            return await _context.Roles
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.RoleId == id);
        }

        public async Task<ICollection<Roles>> GetAllAsync()
        {
            return await _context.Roles
                .AsNoTracking()
                .Where(r => r.Activo)
                .OrderBy(r => r.Nombre)
                .ToListAsync();
        }

        public async Task<Roles> InsertAsync(Roles rol)
        {
            await _context.Roles.AddAsync(rol);
            await _context.SaveChangesAsync();
            return rol;
        }

        public async Task<Roles> UpdateAsync(Roles rol)
        {
            _context.Roles.Update(rol);
            await _context.SaveChangesAsync();
            return rol;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var rol = await _context.Roles.FindAsync(id);
            if (rol == null) return false;

            // Borrado lógico: un rol puede tener usuarios asociados
            rol.Activo = false;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}