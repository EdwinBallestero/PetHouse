using Microsoft.EntityFrameworkCore;
using PetHouse.Infraestructure.Data;
using PetHouse.Infraestructure.Models;
using PetHouse.Infraestructure.Repository.Interfaces;

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
            return await _context.Usuarios
                .AsNoTracking()
                .Include(u => u.Role)
                .Where(u => u.Activo)
                .OrderBy(u => u.UsuarioId)
                .ThenBy(u => u.Apellidos)
                .ToListAsync();
        }

        public async Task<Usuarios?> GetByIdAsync(int id)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.UsuarioId == id);
        }

        public async Task<Usuarios?> GetByCorreoAsync(string correo)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Correo == correo);
        }

        public async Task<Usuarios?> GetByCedulaAsync(string cedula)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Cedula == cedula);
        }

        public async Task<Usuarios> InsertAsync(Usuarios usuario)
        {
            usuario.FechaRegistro = DateTime.Now;
            usuario.Activo = true;

            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuarios> UpdateAsync(Usuarios usuario)
        {
            var existing = await _context.Usuarios.FindAsync(usuario.UsuarioId)
                ?? throw new KeyNotFoundException(
                    $"No existe el usuario con id {usuario.UsuarioId}");

            // Se actualizan solo los campos editables.
            // Password y FechaRegistro NO se tocan aquí.
            existing.RoleId = usuario.RoleId;
            existing.Nombre = usuario.Nombre;
            existing.Apellidos = usuario.Apellidos;
            existing.Telefono = usuario.Telefono;
            existing.Correo = usuario.Correo;
            existing.Direccion = usuario.Direccion;
            existing.FechaNacimiento = usuario.FechaNacimiento;
            existing.Cedula = usuario.Cedula;
            existing.Activo = usuario.Activo;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> UpdatePasswordAsync(int id, string passwordHash)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return false;

            usuario.Password = passwordHash;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return false;

            // Borrado lógico: el usuario tiene mascotas, reservas y facturas
            usuario.Activo = false;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}