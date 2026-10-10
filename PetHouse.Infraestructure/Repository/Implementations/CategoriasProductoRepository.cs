
using Microsoft.EntityFrameworkCore;
using PetHouse.Infraestructure.Data;
using PetHouse.Infraestructure.Models;
using PetHouse.Infraestructure.Repositories.Interfaces;

namespace PetHouse.Infraestructure.Repositories
{
    public class CategoriasProductoRepository
        : ICategoriasProductoRepository
    {
        private readonly PetHouseContext _context;

        public CategoriasProductoRepository(
            PetHouseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoriasProducto>>
            GetAllAsync()
        {
            return await _context.CategoriasProducto
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<CategoriasProducto?> GetByIdAsync(
            int id)
        {
            return await _context.CategoriasProducto
                .FirstOrDefaultAsync(
                    c => c.CategoriaProductoId == id);
        }

        public async Task<CategoriasProducto> InsertAsync(
            CategoriasProducto categoria)
        {
            await _context.CategoriasProducto
                .AddAsync(categoria);

            await _context.SaveChangesAsync();

            return categoria;
        }

        public async Task<CategoriasProducto?> UpdateAsync(
            CategoriasProducto categoria)
        {
            var existente = await _context.CategoriasProducto
                .FirstOrDefaultAsync(
                    c => c.CategoriaProductoId ==
                         categoria.CategoriaProductoId);

            if (existente == null)
                return null;

            existente.Nombre = categoria.Nombre;
            existente.Descripcion = categoria.Descripcion;
            existente.Activo = categoria.Activo;

            await _context.SaveChangesAsync();

            return existente;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var categoria = await _context.CategoriasProducto
                .FirstOrDefaultAsync(
                    c => c.CategoriaProductoId == id);

            if (categoria == null)
                return false;

            _context.CategoriasProducto.Remove(categoria);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
