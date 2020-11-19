using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Learningcsharp.Controllers.Dtos.Characters;
using Learningcsharp.Data;
using Learningcsharp.Dtos.Weapons;
using Learningcsharp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Learningcsharp.Services.WeaponService
{
    public class WeaponService : IWeaponService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapping;
        public WeaponService(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper mapping)
        {
            _mapping = mapping;
            _httpContextAccessor = httpContextAccessor;
            _context = context;

        }
        public async Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == newWeapon.CharacterId && 
                    c.Users.Id == int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));
                    if(character == null)
                    {
                        response.Success = false;
                        response.Message = "Character not found";
                        return response;
                    }
                    Weapon weapon  = new Weapon
                    {
                        Name = newWeapon.Name,
                        Damage = newWeapon.Damage,
                        character = character
                    };

                    await _context.weapons.AddAsync(weapon);
                    await _context.SaveChangesAsync();

                    response.Data = _mapping.Map<GetCharacterDto>(character);
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}