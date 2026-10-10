using AutoMapper;
using PetHouse.Application.DTOs;
using PetHouse.Infraestructure.Models;

namespace PetHouse.Application.Profiles
{
    public class RolesProfile : Profile
    {
        public RolesProfile()
        {
            CreateMap<Roles, RolesDTO>();

            CreateMap<RolesDTO, Roles>()
                .ForMember(dest => dest.Usuarios, opt => opt.Ignore());
        }
    }
}