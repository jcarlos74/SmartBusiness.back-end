using System.Collections.Generic;
using AutoMapper;
using SmartBusiness.Api.Dtos;
using SmartBusiness.Domain.Entities.CtAcesso;
using SmartBusiness.Identity.Models;

namespace SmartBusiness.Infra
{
    public class AutoMapperProfiles : Profile   
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserApp,ApplicationUser >().ReverseMap();
            //CreateMap<VwCtaItensMenuGrupo, ItensMenuGrupo>().ReverseMap();

            //CreateMap<Palestrante, PalestranteDto>()
            //    .ForMember(dest => dest.Eventos, opt => {
            //        opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Evento).ToList());
            //    })
            //    .ReverseMap();

            //CreateMap<Lote, LoteDto>().ReverseMap();
            //CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();

            //CreateMap<User, UserDto>().ReverseMap();
            //CreateMap<User, UserLoginDto>().ReverseMap();
        }
    }
}
