using AutoMapper;
using pratica.Dtos;
using pratica.Models;

namespace pratica.MapperConfigure
{
    public class Mapper : Profile
    {

        public Mapper()
        {
            CreateMap<Socio, SocioDTO>();
        }
    }
}
