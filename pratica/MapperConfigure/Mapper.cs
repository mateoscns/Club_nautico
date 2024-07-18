using AutoMapper;
using pratica.Dtos;
using pratica.Models;
using pratica.Services.BarcosServices.Commands;

public class Mapper : Profile
{
    public Mapper()
    {
        // Mapeo entre Socio y SocioDTO
        CreateMap<Socio, SocioDTO>();
        CreateMap<SocioDTO, Socio>();

        // Mapeo entre Barco y BarcoDTO
        CreateMap<Barco, BarcoDTO>()
            .ForMember(dest => dest.Socio, opt => opt.MapFrom(src => src.IdSocioNavigation));

        CreateMap<BarcoDTO, Barco>()
            .ForMember(dest => dest.IdSocioNavigation, opt => opt.Ignore());

        // Mapeo entre PostBarcoCommand y Barco
        CreateMap<PostBarco.PostBarcoCommand, Barco>()
            .ForMember(dest => dest.IdSocioNavigation, opt => opt.Ignore());
    }
}
