using System.Threading.Tasks;
using Learningcsharp.Dtos.Weapons;
using Learningcsharp.Services.WeaponService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Learningcsharp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeaponController : ControllerBase
    {
        private readonly IWeaponService _weapons;
        public WeaponController(IWeaponService weapons)
        {
            _weapons = weapons;
        }

        [HttpPost]
        public async Task<IActionResult> AddWeapon(AddWeaponDto newWeapon)
        {
            return Ok(await _weapons.AddWeapon(newWeapon));
        }
    }
}