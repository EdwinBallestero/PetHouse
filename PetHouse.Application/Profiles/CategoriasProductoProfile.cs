
using AutoMapper;
using PetHouse.Application.DTOs;
using PetHouse.Infraestructure.Models;

namespace PetHouse.Application.Profiles
{
    public class CategoriasProductoProfile : Profile
    {
        public CategoriasProductoProfile()
        {
            CreateMap<CategoriasProducto, CategoriasProductoDTO>();

            CreateMap<CategoriasProductoDTO, CategoriasProducto>();
        }
    }
}
