using AutoMapper;
using Learningcsharp.Controllers.Dtos.Characters;
using Learningcsharp.Dtos.Weapons;
using Learningcsharp.Models;

namespace Learningcsharp
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<Weapon, GetWeaponDto>();
        }
    }
}