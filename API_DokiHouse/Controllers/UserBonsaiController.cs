using BLL_DokiHouse.Interfaces;
using DAL_DokiHouse.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_DokiHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBonsaiController : ControllerBase
    {
        #region INJECTION
        private readonly IUserBonsaiBLLService _userBLLService;
        public UserBonsaiController(IUserBonsaiBLLService userBLLService) => _userBLLService = userBLLService;
        #endregion


        /// <summary>
        /// Récupère la liste des utilisateurs avec leurs infos bonsais.
        /// </summary>
        /// <remarks>
        /// Cette méthode permet de récupérer la liste complète des utilisateurs sur base d'une pagination.
        /// </remarks>
        /// <param name="startIndex">Représente l'index de départ, param de type : 'int', valeur par défaut : 1</param>
        /// <param name="pageSize">Représente le nombre d'utilisateur à récupérer, param de type : 'int', valeur par défaut : 12</param>
        /// <response code="200">Retourne la liste des utilisateurs.</response>
        /// <response code="204">Aucun utilisateur n'est trouvé.</response>
        /// <response code="400">La requête n'est pas correct.</response>
        /// <response code="401">Vous n'êtes pas autorisée.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserAndBonsaiDetails>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Get([FromQuery] int startIndex = 1, [FromQuery] int pageSize = 12)
        {
            if (startIndex < 1) return BadRequest("Le paramètre startIndex doit être supérieur à zéro");
            if (pageSize < 1) return BadRequest("Le paramètre pageSize doit être supérieur à zéro");

            startIndex--;

            IEnumerable<UserAndBonsaiDetails?> result = await _userBLLService.GetInfos(startIndex, pageSize);

            return result is null
                ? NoContent()
                : Ok(result);
        }


        /// <summary>
        /// Récupère un utilisateur sur base de son identifiant de type int et ses bonsais.
        /// </summary>
        /// <param name="idUser">Représente l'identifiant de l'utilisateur rechercher, param de type : 'int'</param>
        /// <response code="200">Retourne un utilisateur.</response>
        /// <response code="204">Aucun utilisateur n'est trouvé.</response>
        /// <response code="400">La requête n'est pas correct.</response>
         /// <response code="401">Vous n'êtes pas autorisée.</response>
        [HttpGet("{idUser:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserAndBonsaiDetails))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Get(int idUser)
        {
            UserAndBonsaiDetails? result = await _userBLLService.GetInfosById(idUser);

            return result is null
                ? NoContent()
                : Ok(result);
        }



    }
}
