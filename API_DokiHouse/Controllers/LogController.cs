using API_DokiHouse.Models;
using BLL_DokiHouse.Interfaces;
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


        /// <summary>
        /// Méthode permettant de gérer la requête HTTP POST pour l'authentification d'un utilisateur.
        /// </summary>
        /// <param name="user">Modèle contenant les informations d'authentification de l'utilisateur.</param>
        /// <returns>
        /// Retourne un objet IActionResult représentant le résultat de l'opération d'authentification.
        /// </returns>
        /// <response code="200">Authentification réussie. Retourne un jeton d'authentification.</response>
        /// <response code="400">La requête est incorrecte ou les informations d'authentification sont invalides.</response>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginModel user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _userBLLService.Login(user.Email, user.Passwd);

            if (result is not null)
            {
                string token = _jwtService.GenerateToken(result.Id.ToString(), result.Role);

                return Ok(token); //--> peut être envoyé sous forme d'objet au Front `Ok(new {token})`
            }

            return BadRequest("Infos non valide !");
        }


    }
}

