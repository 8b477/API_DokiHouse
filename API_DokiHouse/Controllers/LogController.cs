using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Models.User;
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


        /// <summary>
        /// Méthode permettant de gérer l'authentification d'un utilisateur.
        /// </summary>
        /// <param name="user">Modèle contenant les informations d'authentification de l'utilisateur.</param>
        /// <returns>
        /// Retourne un objet IActionResult représentant le résultat de l'opération d'authentification.
        /// </returns>
        /// <response code="200">Authentification réussie. Retourne un jeton d'authentification.</response>
        /// <response code="400">La requête est incorrecte ou les informations d'authentification sont invalides. Le message explicatif est fourni dans le corps de la réponse.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> Login([FromBody] UserLogModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest("La requête est incorrecte. Veuillez fournir des informations d'authentification valides.");

            User? result = await _userBLLService.Login(user.Email, user.Passwd);

            if (result is not null)
            {
                string token = _jwtService.GenerateToken(result.Id.ToString(), result.Name, result.Role);
                return Ok( token);
            }

            return BadRequest("Les informations d'authentification sont invalides. Veuillez vérifier votre email et votre mot de passe.");
        }



    }
}

