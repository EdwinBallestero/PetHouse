
using AutoMapper;
using PetHouse.Application.DTOs;
using PetHouse.Application.Services.Interfaces;
using PetHouse.Infraestructure.Models;
using PetHouse.Infraestructure.Repositories.Interfaces;

namespace PetHouse.Application.Services
{
    public class ProductosService : IProductosService
    {
        private readonly IProductosRepository _productosRepository;
        private readonly IMapper _mapper;

        public ProductosService(
            IProductosRepository productosRepository,
            IMapper mapper)
        {
            _productosRepository = productosRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductosDTO>> GetAllAsync()
        {
            var productos = await _productosRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ProductosDTO>>(productos);
        }

        public async Task<ProductosDTO?> GetByIdAsync(int id)
        {
            var producto = await _productosRepository.GetByIdAsync(id);

            if (producto == null)
                return null;

            return _mapper.Map<ProductosDTO>(producto);
        }

        public async Task<ProductosDTO> InsertAsync(ProductosDTO dto)
        {
            var producto = _mapper.Map<Productos>(dto);

            var productoCreado =
                await _productosRepository.InsertAsync(producto);

            return _mapper.Map<ProductosDTO>(productoCreado);
        }

        public async Task<ProductosDTO?> UpdateAsync(ProductosDTO dto)
        {
            var producto = _mapper.Map<Productos>(dto);

            var productoActualizado =
                await _productosRepository.UpdateAsync(producto);

            if (productoActualizado == null)
                return null;

            return _mapper.Map<ProductosDTO>(productoActualizado);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _productosRepository.DeleteAsync(id);
        }
    }
}
