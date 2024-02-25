using AutoMapper;
using WebAPICodeFirst.DTO;
using WebAPICodeFirst.Model;

namespace WebAPICodeFirst.Configurations
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<Hasta,HastaDTO>().ReverseMap();
        }
    }
}
