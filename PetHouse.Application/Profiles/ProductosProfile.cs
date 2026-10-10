
using AutoMapper;
using PetHouse.Application.DTOs;
using PetHouse.Infraestructure.Models;

namespace PetHouse.Application.Profiles
{
    public class ProductosProfile : Profile
    {
        public ProductosProfile()
        {
            CreateMap<Productos, ProductosDTO>()
                .ForMember(
                    dest => dest.NombreCategoria,
                    opt => opt.MapFrom(
                        src => src.CategoriaProducto.Nombre));

            CreateMap<ProductosDTO, Productos>();
        }
    }
}
