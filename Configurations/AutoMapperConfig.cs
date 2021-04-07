using AutoMapper;
using CoronaVirus.Api.Data.Collections;
using CoronaVirus.Api.Models;
using MongoDB.Driver.GeoJsonObjectModel;

namespace CoronaVirus.Api.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<InfectadoDTO, Infectado>()
                .ForMember(dest => dest.Localizacao, 
                opt => opt.MapFrom(src => new GeoJson2DGeographicCoordinates(src.Longitude, src.Latitude)));

            CreateMap<Infectado, InfectadoDTO>()
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Localizacao.Longitude))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Localizacao.Latitude));
        }
    }
}