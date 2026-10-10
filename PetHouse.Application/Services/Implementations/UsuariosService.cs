using AutoMapper;
using PetHouse.Application.DTOs;
using PetHouse.Application.Services.Interfaces;
using PetHouse.Infraestructure.Models;
using PetHouse.Infraestructure.Repository.Interfaces;

namespace PetHouse.Application.Services.Implementations
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IRolRepository _rolRepository;
        private readonly IMapper _mapper;

        public UsuariosService(
            IUsuarioRepository repository,
            IRolRepository rolRepository,
            IMapper mapper)
        {
            _repository = repository;
            _rolRepository = rolRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<UsuariosDTO>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<ICollection<UsuariosDTO>>(list);
        }

        public async Task<UsuariosDTO?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<UsuariosDTO>(entity);
        }

        public async Task<UsuariosDTO> InsertAsync(UsuariosDTO dto)
        {
            ValidarDatosBasicos(dto);   // <-- agregado

            if (string.IsNullOrWhiteSpace(dto.Password) || dto.Password.Length < 6)
                throw new InvalidOperationException("La contraseña debe tener al menos 6 caracteres.");

            var correo = dto.Correo.Trim().ToLowerInvariant();
            var cedula = dto.Cedula.Trim();

            await ValidarRolAsync(dto.RoleId);

            if (await _repository.GetByCorreoAsync(correo) != null)
                throw new InvalidOperationException("Ya existe un usuario con ese correo.");

            if (await _repository.GetByCedulaAsync(cedula) != null)
                throw new InvalidOperationException("Ya existe un usuario con esa cédula.");

            var entity = _mapper.Map<Usuarios>(dto);
            entity.UsuarioId = 0;
            entity.Correo = correo;
            entity.Cedula = cedula;
            entity.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var inserted = await _repository.InsertAsync(entity);

            // Se vuelve a leer para que venga con el nombre del rol
            var completo = await _repository.GetByIdAsync(inserted.UsuarioId);
            return _mapper.Map<UsuariosDTO>(completo);
        }

        public async Task<UsuariosDTO?> UpdateAsync(UsuariosDTO dto)
        {
            ValidarDatosBasicos(dto);   // <-- agregado

            var existing = await _repository.GetByIdAsync(dto.UsuarioId);
            if (existing == null) return null;

            var correo = dto.Correo.Trim().ToLowerInvariant();
            var cedula = dto.Cedula.Trim();

            await ValidarRolAsync(dto.RoleId);

            var porCorreo = await _repository.GetByCorreoAsync(correo);
            if (porCorreo != null && porCorreo.UsuarioId != dto.UsuarioId)
                throw new InvalidOperationException("Ya existe otro usuario con ese correo.");

            var porCedula = await _repository.GetByCedulaAsync(cedula);
            if (porCedula != null && porCedula.UsuarioId != dto.UsuarioId)
                throw new InvalidOperationException("Ya existe otro usuario con esa cédula.");

            // Si viene contraseña, se valida ANTES de guardar nada
            if (!string.IsNullOrWhiteSpace(dto.Password) && dto.Password.Length < 6)
                throw new InvalidOperationException("La contraseña debe tener al menos 6 caracteres.");

            var entity = _mapper.Map<Usuarios>(dto);
            entity.Correo = correo;
            entity.Cedula = cedula;

            await _repository.UpdateAsync(entity);

            // Contraseña nueva: se cambia. Vacía: se deja la actual.
            if (!string.IsNullOrWhiteSpace(dto.Password))
            {
                var hash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
                await _repository.UpdatePasswordAsync(dto.UsuarioId, hash);
            }

            var completo = await _repository.GetByIdAsync(dto.UsuarioId);
            return _mapper.Map<UsuariosDTO>(completo);
        }

        public async Task<UsuariosDTO?> LoginAsync(UsuariosDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Correo) || string.IsNullOrWhiteSpace(dto.Password))
                return null;

            var correo = dto.Correo.Trim().ToLowerInvariant();

            var usuario = await _repository.GetByCorreoAsync(correo);
            if (usuario == null || !usuario.Activo) return null;

            if (!VerificarPassword(dto.Password, usuario.Password)) return null;

            return _mapper.Map<UsuariosDTO>(usuario);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        // ---------- Métodos privados ----------

        private async Task ValidarRolAsync(int roleId)
        {
            var rol = await _rolRepository.GetByIdAsync(roleId);
            if (rol == null || !rol.Activo)
                throw new InvalidOperationException("El rol indicado no existe o está inactivo.");
        }

        private static bool VerificarPassword(string passwordPlano, string hashGuardado)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(passwordPlano, hashGuardado);
            }
            catch (BCrypt.Net.SaltParseException)
            {
                // El valor guardado no es un hash BCrypt (texto plano antiguo)
                return false;
            }
        }

        private static void ValidarDatosBasicos(UsuariosDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nombre))
                throw new InvalidOperationException("El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(dto.Apellidos))
                throw new InvalidOperationException("Los apellidos son obligatorios.");
            if (string.IsNullOrWhiteSpace(dto.Correo))
                throw new InvalidOperationException("El correo es obligatorio.");
            if (string.IsNullOrWhiteSpace(dto.Cedula))
                throw new InvalidOperationException("La cédula es obligatoria.");
        }
    }
}