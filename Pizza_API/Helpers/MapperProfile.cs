using AutoMapper;
using Pizza_Core.DTOs;

using Pizza_Core.Models;


namespace Pizza_API.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            // cette ligne permet de dire qu'a l'aide du mapper on pourra passer de l'entité vers le DTO
            // et vice versa grace au .ReverseMap()
            CreateMap<User, RegisterDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();


        }
    }
}
