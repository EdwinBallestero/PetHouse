using AutoMapper;
using PetHouse.Application.DTOs;
using PetHouse.Infraestructure.Models;

namespace PetHouse.Application.Profiles
{
    public class UsuariosProfile : Profile
    {
        public UsuariosProfile()
        {
            // Entidad -> DTO: la contraseña nunca sale
            CreateMap<Usuarios, UsuariosDTO>()
                .ForMember(d => d.Password, o => o.Ignore());

            // DTO -> Entidad: el hash lo pone el servicio
            CreateMap<UsuariosDTO, Usuarios>()
                .ForMember(d => d.Password, o => o.Ignore())
                .ForMember(d => d.Role, o => o.Ignore());
        }
    }
}