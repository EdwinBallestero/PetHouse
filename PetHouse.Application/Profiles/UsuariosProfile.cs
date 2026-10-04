using AutoMapper;
using PetHouse.Application.DTOs;
using PetHouse.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.Application.Profiles
{
    public class UsuariosProfile : Profile
    {
        public UsuariosProfile()
        {
            CreateMap<Usuarios, UsuariosDTO>().ReverseMap();
        }
    }
}   

