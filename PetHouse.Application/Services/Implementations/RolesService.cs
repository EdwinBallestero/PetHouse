using AutoMapper;
using PetHouse.Application.DTOs;
using PetHouse.Application.Services.Interfaces;
using PetHouse.Infraestructure.Models;
using PetHouse.Infraestructure.Repository.Interfaces;

namespace PetHouse.Application.Services.Implementations
{
    public class RolesService : IRolesService
    {
        private readonly IRolRepository _repository;
        private readonly IMapper _mapper;

        public RolesService(IRolRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RolesDTO?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<RolesDTO>(entity);
        }

        public async Task<ICollection<RolesDTO>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<ICollection<RolesDTO>>(list);
        }

        public async Task<RolesDTO> InsertAsync(RolesDTO dto)
        {
            var entity = _mapper.Map<Roles>(dto);
            entity.Activo = true; // un rol nuevo siempre nace activo
            var inserted = await _repository.InsertAsync(entity);
            return _mapper.Map<RolesDTO>(inserted);
        }

        public async Task<RolesDTO?> UpdateAsync(RolesDTO dto)
        {
            var existing = await _repository.GetByIdAsync(dto.RoleId);
            if (existing == null) return null;

            var entity = _mapper.Map<Roles>(dto);
            var updated = await _repository.UpdateAsync(entity);
            return _mapper.Map<RolesDTO>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}