using AutoMapper;
using Learningcsharp.Controllers.Dtos.Characters;
using Learningcsharp.Models;

namespace Learningcsharp
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
        }
    }
}