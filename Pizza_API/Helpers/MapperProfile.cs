using AutoMapper;
using Pizza_API.DTOs;
using Pizza_API.Models;

namespace Pizza_API.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Pizza, PizzaDTO>().ReverseMap();
            // cette ligne permet de dire qu'a l'aide du mapper on pourra passer de l'entité vers le DTO
            // et vice versa grace au .ReverseMap()
            CreateMap<Ingredient, IngredientDTO>().ReverseMap();
            CreateMap<User, RegisterDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();


        }
    }
}
