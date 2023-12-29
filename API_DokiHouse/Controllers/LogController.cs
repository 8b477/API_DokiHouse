using API_DokiHouse.Models;
using BLL_DokiHouse.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_DokiHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LogController : ControllerBase
    {

        #region Injection

        private readonly IUserBLLService _userBLLService;

        public LogController(IUserBLLService userBLLService) => (_userBLLService) = (userBLLService); 

        #endregion



        // ----------> Ici je dois générer mon token côté API et le set avec le role et l'id du User loggé
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserRegisterModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _userBLLService.Login(user.Email, user.Passwd) is not null)
                return Ok("Connecter !");

            return BadRequest("Infos non valide !");
        }


    }
}

