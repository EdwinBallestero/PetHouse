using Microsoft.EntityFrameworkCore;
using PetHouse.Infraestructure.Data;
using PetHouse.Infraestructure.Models;
using PetHouse.Infraestructure.Repositories.Interfaces;

namespace PetHouse.Infraestructure.Repositories
{
    public class ProductosRepository : IProductosRepository
    {
        private readonly PetHouseContext _context;

        public ProductosRepository(PetHouseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Productos>> GetAllAsync()
        {
            return await _context.Productos
                .AsNoTracking()
                .Include(p => p.CategoriaProducto)
                .ToListAsync();
        }

        public async Task<Productos?> GetByIdAsync(int id)
        {
            return await _context.Productos
                .Include(p => p.CategoriaProducto)
                .FirstOrDefaultAsync(p => p.ProductoId == id);
        }

        public async Task<Productos> InsertAsync(Productos producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();

            return producto;
        }

        public async Task<Productos?> UpdateAsync(Productos producto)
        {
            var existente = await _context.Productos
                .FirstOrDefaultAsync(p => p.ProductoId == producto.ProductoId);

            if (existente == null)
                return null;

            existente.CategoriaProductoId = producto.CategoriaProductoId;
            existente.Nombre = producto.Nombre;
            existente.Descripcion = producto.Descripcion;
            existente.Precio = producto.Precio;
            existente.Stock = producto.Stock;
            existente.StockMinimo = producto.StockMinimo;
            existente.Marca = producto.Marca;
            existente.Activo = producto.Activo;
            existente.ImagenUrl = producto.ImagenUrl;

            await _context.SaveChangesAsync();

            return existente;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var producto = await _context.Productos
                .FirstOrDefaultAsync(p => p.ProductoId == id);

            if (producto == null)
                return false;

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
