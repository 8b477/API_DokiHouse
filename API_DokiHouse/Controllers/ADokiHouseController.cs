using API_DokiHouse.Tools;

using AutoMapper.Configuration.Conventions;

using BLL_DokiHouse.Interfaces;
using DAL_DokiHouse.DTO;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Tools_DokiHouse.Filters.JwtIdentifiantFilter;

namespace API_DokiHouse.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(JwtUserIdentifiantFilter))]
    [ApiController]
    public class ADokiHouseController : ControllerBase
    {


        #region Injection

        private readonly IADokiHouseBLLService _dokiHouseBLLService;
        private readonly GetInfosHTTPContext _getInfosHTTPContext;
        public ADokiHouseController(IADokiHouseBLLService dokiHouseBLLService, GetInfosHTTPContext getInfosHTTPContext)
            => (_dokiHouseBLLService, _getInfosHTTPContext) = (dokiHouseBLLService, getInfosHTTPContext);

        #endregion


        //_______________________________
        //                               /
        //           GLOBAL INFOS        /
        //______________________________ /


        /// <summary>
        /// Obtient des informations sur un utilisateur avec ses Posts et ses commentaires associés.
        /// </summary>
        /// <param name="idUser">Identifiant de l'utilisateur de type : 'int'.</param>
        /// <returns>Retourne une liste d'objets <see cref="BlogDTO"/> contenant les informations complètes.</returns>
        [AllowAnonymous]
        [HttpGet("{idUser}:int")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BlogDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetBlogs([FromRoute] int idUser)
        {
            var result = await _dokiHouseBLLService.GetUserInfosWithOwnPostsAndComments(idUser);

            return
                result is not null
                ? Ok(result)
                : NoContent();
        }



        [AllowAnonymous]
        [HttpGet(nameof(OwnPostsAndComments))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BlogDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> OwnPostsAndComments()
        {

            int idToken = _getInfosHTTPContext.GetIdUserTokenInHttpContext();

            if (idToken == 0) return Unauthorized();

            var result = await _dokiHouseBLLService.GetUserInfosWithOwnPostsAndComments(idToken);

            return
                result is not null
                ? Ok(result)
                : NoContent();
        }



        [AllowAnonymous]
        [HttpGet(nameof(OwnBonsaisAndDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BlogDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> OwnBonsaisAndDetails([FromQuery] int startIndex = 1, [FromQuery] int pageSize = 12)
        {
            if (startIndex < 1 || pageSize < 1)
                return BadRequest("La page et la taille de la page doivent être des valeurs positives.");

            startIndex--;

            var result = await _dokiHouseBLLService.GetInfosUserWithOwnBonsaisAndDetails(startIndex, pageSize);

            return
                result is not null
                ? Ok(result)
                : NoContent();
        }


        [AllowAnonymous]
        [HttpGet(nameof(GetBonsaisAndDetailsById) + "/{idUser}:int")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BlogDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetBonsaisAndDetailsById(int idUser, [FromQuery] int startIndex = 1, [FromQuery] int pageSize = 12)
        {
            if (startIndex < 1 || pageSize < 1)
                return BadRequest("La page et la taille de la page doivent être des valeurs positives.");

            startIndex--;

            var result = await _dokiHouseBLLService.GetInfosUserWithBonsaisAndDetailsById(idUser, startIndex, pageSize);

            return
                result is not null
                ? Ok(result)
                : NoContent();
        }
    }
}
