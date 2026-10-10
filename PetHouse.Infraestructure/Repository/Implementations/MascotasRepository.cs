
using Microsoft.EntityFrameworkCore;
using PetHouse.Infraestructure.Data;
using PetHouse.Infraestructure.Models;
using PetHouse.Infraestructure.Repositories.Interfaces;

namespace PetHouse.Infraestructure.Repositories
{
    public class MascotasRepository : IMascotasRepository
    {
        private readonly PetHouseContext _context;

        public MascotasRepository(PetHouseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Mascotas>> GetAllAsync()
        {
            return await _context.Mascotas
                .AsNoTracking()
                .Include(m => m.Usuario)
                .Include(m => m.Raza)
                .ToListAsync();
        }

        public async Task<Mascotas?> GetByIdAsync(int id)
        {
            return await _context.Mascotas
                .Include(m => m.Usuario)
                .Include(m => m.Raza)
                .FirstOrDefaultAsync(m => m.MascotaId == id);
        }

        public async Task<Mascotas> InsertAsync(Mascotas mascota)
        {
            await _context.Mascotas.AddAsync(mascota);
            await _context.SaveChangesAsync();

            return mascota;
        }

        public async Task<Mascotas?> UpdateAsync(Mascotas mascota)
        {
            var existente = await _context.Mascotas
                .FirstOrDefaultAsync(
                    m => m.MascotaId == mascota.MascotaId);

            if (existente == null)
                return null;

            existente.UsuarioId = mascota.UsuarioId;
            existente.RazaId = mascota.RazaId;
            existente.Nombre = mascota.Nombre;
            existente.FechaNacimiento = mascota.FechaNacimiento;
            existente.Sexo = mascota.Sexo;
            existente.Peso = mascota.Peso;
            existente.Color = mascota.Color;
            existente.Descripcion = mascota.Descripcion;
            existente.Alergias = mascota.Alergias;
            existente.CaracteristicasEspeciales =
                mascota.CaracteristicasEspeciales;
            existente.Activo = mascota.Activo;

            await _context.SaveChangesAsync();

            return existente;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var mascota = await _context.Mascotas
                .FirstOrDefaultAsync(m => m.MascotaId == id);

            if (mascota == null)
                return false;

            _context.Mascotas.Remove(mascota);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
