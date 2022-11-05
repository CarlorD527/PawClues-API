using AutoMapper;
using Core.Entities;
using PawCluesAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {


            CreateMap<Mascota, MascotaDto>();
            CreateMap<MascotaDto, Mascota>();

        }
    }
}
