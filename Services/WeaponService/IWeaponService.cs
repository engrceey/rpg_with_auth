using System.Threading.Tasks;
using Learningcsharp.Controllers.Dtos.Characters;
using Learningcsharp.Dtos.Weapons;
using Learningcsharp.Models;

namespace Learningcsharp.Services.WeaponService
{
    public interface IWeaponService
    {
         Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newweapon);
    }
}