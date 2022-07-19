using AutoMapper;
using iCoreAPI.DTOs;
using iCoreAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iCoreAPI.Hellpers
{
    public class AuotMapperProfile : Profile
    {
        public AuotMapperProfile()
        {
            CreateMap<GenreDTO, Genre>().ReverseMap();
            CreateMap<GenreCreationDTO, Genre>();

            CreateMap<DealerDTO, Dealer>().ReverseMap();
            CreateMap<DealerCreationDTO, Dealer>().ForMember(x => x.picture, option => option.Ignore());
        }
    }
}
