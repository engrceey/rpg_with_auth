using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Learningcsharp.Controllers.Dtos.Characters;
using Learningcsharp.Controllers.Services.CharacterService;
using Learningcsharp.Dtos.Characters;
using Learningcsharp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Learningcsharp.Controllers
{

    [Authorize(Roles = "Player, Admin")]
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _service;

        public CharacterController(ICharacterService service)
        {
            _service = service;

        }

        // [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {

            return Ok(await _service.GetCharacterById(id));
        }


        [HttpPost]
        public async Task<IActionResult> AddCharacter(AddCharacterDto newCharacter)
        {
            return Ok(await _service.AddCharacter(newCharacter));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto newCharacter)
        {
            return Ok(await _service.UpdateCharacter(newCharacter));
        }

         [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _service.DeleteCharacter(id));
        }
    }
}