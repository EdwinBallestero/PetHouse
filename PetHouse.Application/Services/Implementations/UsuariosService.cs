using AutoMapper;
using PetHouse.Application.DTOs;
using PetHouse.Application.Services.Interfaces;
using PetHouse.Infraestructure.Models;
using PetHouse.Infraestructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.Application.Services.Implementations
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IUsuarioRepository _repository; private readonly IMapper _mapper;
        public UsuariosService(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UsuariosDTO?> GetByIdAsync(int id)
        {
            var @object = await _repository.GetByIdAsync(id);
            var objectMapped = _mapper.Map<UsuariosDTO>(@object);
            return objectMapped;
        }

        public async Task<ICollection<UsuariosDTO>> GetAllAsync()
        {
            //Obtener datos del repositorio
            var list = await _repository.GetAllAsync();
            //Map List<Usuarios> a ICollection<UsuariosDTO> 
            var collection = _mapper.Map<ICollection<UsuariosDTO>>(list);
            // Return lista
            return collection;
        }
        public async Task<UsuariosDTO> InsertAsync(UsuariosDTO dto)
        {
            var entity = _mapper.Map<Usuarios>(dto);
            var inserted = await _repository.InsertAsync(entity);
            return _mapper.Map<UsuariosDTO>(inserted);
        }

        public async Task<UsuariosDTO?> UpdateAsync(UsuariosDTO dto)
        {
            var existing = await _repository.GetByIdAsync(dto.UsuarioId);
            if (existing == null) return null;

            var entity = _mapper.Map<Usuarios>(dto);
            var updated = await _repository.UpdateAsync(entity);
            return _mapper.Map<UsuariosDTO>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
