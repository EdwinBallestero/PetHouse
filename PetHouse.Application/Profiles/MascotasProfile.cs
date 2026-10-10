
using AutoMapper;
using PetHouse.Application.DTOs;
using PetHouse.Infraestructure.Models;

namespace PetHouse.Application.Profiles
{
    public class MascotasProfile : Profile
    {
        public MascotasProfile()
        {
            CreateMap<Mascotas, MascotasDTO>()
                .ForMember(
                    dest => dest.NombreRaza,
                    opt => opt.MapFrom(
                        src => src.Raza != null
                            ? src.Raza.Nombre
                            : null))
                .ForMember(
                    dest => dest.NombreUsuario,
                    opt => opt.MapFrom(
                        src => src.Usuario.Nombre));

            CreateMap<MascotasDTO, Mascotas>()
                .ForMember(
                    dest => dest.Raza,
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.Usuario,
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.Reservas,
                    opt => opt.Ignore());
        }
    }
}
