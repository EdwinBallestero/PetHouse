
using AutoMapper;
using PetHouse.Application.DTOs;
using PetHouse.Application.Services.Interfaces;
using PetHouse.Infraestructure.Models;
using PetHouse.Infraestructure.Repositories.Interfaces;

namespace PetHouse.Application.Services
{
    public class CategoriasProductoService
        : ICategoriasProductoService
    {
        private readonly ICategoriasProductoRepository
            _categoriasRepository;

        private readonly IMapper _mapper;

        public CategoriasProductoService(
            ICategoriasProductoRepository categoriasRepository,
            IMapper mapper)
        {
            _categoriasRepository = categoriasRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriasProductoDTO>>
            GetAllAsync()
        {
            var categorias =
                await _categoriasRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<CategoriasProductoDTO>>(
                categorias);
        }

        public async Task<CategoriasProductoDTO?> GetByIdAsync(
            int id)
        {
            var categoria =
                await _categoriasRepository.GetByIdAsync(id);

            if (categoria == null)
                return null;

            return _mapper.Map<CategoriasProductoDTO>(categoria);
        }

        public async Task<CategoriasProductoDTO> InsertAsync(
            CategoriasProductoDTO dto)
        {
            var categoria =
                _mapper.Map<CategoriasProducto>(dto);

            var creada =
                await _categoriasRepository.InsertAsync(categoria);

            return _mapper.Map<CategoriasProductoDTO>(creada);
        }

        public async Task<CategoriasProductoDTO?> UpdateAsync(
            CategoriasProductoDTO dto)
        {
            var categoria =
                _mapper.Map<CategoriasProducto>(dto);

            var actualizada =
                await _categoriasRepository.UpdateAsync(categoria);

            if (actualizada == null)
                return null;

            return _mapper.Map<CategoriasProductoDTO>(actualizada);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _categoriasRepository.DeleteAsync(id);
        }
    }
}
