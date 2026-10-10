
using AutoMapper;
using PetHouse.Application.DTOs;
using PetHouse.Application.Services.Interfaces;
using PetHouse.Infraestructure.Models;
using PetHouse.Infraestructure.Repositories.Interfaces;

namespace PetHouse.Application.Services
{
    public class MascotasService : IMascotasService
    {
        private readonly IMascotasRepository _mascotasRepository;
        private readonly IMapper _mapper;

        public MascotasService(
            IMascotasRepository mascotasRepository,
            IMapper mapper)
        {
            _mascotasRepository = mascotasRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MascotasDTO>> GetAllAsync()
        {
            var mascotas =
                await _mascotasRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<MascotasDTO>>(mascotas);
        }

        public async Task<MascotasDTO?> GetByIdAsync(int id)
        {
            var mascota =
                await _mascotasRepository.GetByIdAsync(id);

            if (mascota == null)
                return null;

            return _mapper.Map<MascotasDTO>(mascota);
        }

        public async Task<MascotasDTO> InsertAsync(
            MascotasDTO dto)
        {
            var mascota = _mapper.Map<Mascotas>(dto);

            var creada =
                await _mascotasRepository.InsertAsync(mascota);

            return _mapper.Map<MascotasDTO>(creada);
        }

        public async Task<MascotasDTO?> UpdateAsync(
            MascotasDTO dto)
        {
            var mascota = _mapper.Map<Mascotas>(dto);

            var actualizada =
                await _mascotasRepository.UpdateAsync(mascota);

            if (actualizada == null)
                return null;

            return _mapper.Map<MascotasDTO>(actualizada);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _mascotasRepository.DeleteAsync(id);
        }
    }
}
