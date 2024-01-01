using API_DokiHouse.Models;
using BLL_DokiHouse.Interfaces;

using Entities_DokiHouse.Entities;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Tools_DokiHouse.Token;

namespace API_DokiHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LogController : ControllerBase
    {

        #region Injection

        private readonly IUserBLLService _userBLLService;
        private readonly JWTService _jwtService;

        public LogController(IUserBLLService userBLLService, JWTService jWTService)
            => (_userBLLService, _jwtService) 
            =  (userBLLService, jWTService); 

        #endregion


        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginModel user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            User? result = await _userBLLService.Login(user.Email, user.Passwd);

            if (result is not null)
            {
                string token = _jwtService.GenerateToken(result.Id.ToString(), result.Role);

                return Ok(token);
            }

            return BadRequest("Infos non valide !");
        }


    }
}

