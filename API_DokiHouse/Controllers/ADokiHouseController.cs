using BLL_DokiHouse.Interfaces;
using DAL_DokiHouse.DTO;

using Microsoft.AspNetCore.Mvc;

namespace API_DokiHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ADokiHouseController : ControllerBase
    {


        #region Injection

        private readonly IADokiHouseBLLService _dokiHouseBLLService;
        public ADokiHouseController(IADokiHouseBLLService dokiHouseBLLService) => _dokiHouseBLLService = dokiHouseBLLService;

        #endregion


        //_______________________________
        //                               /
        //           GLOBAL INFOS        /
        //______________________________ /

        /// <summary>
        /// Obtient les informations complètes sur les utilisateurs avec leurs bonsaïs, catégories, styles et notes associés.
        /// </summary>
        /// <param name="cancellationToken">Token d'annulation pour arrêter la requête de manière asynchrone si nécessaire.</param>
        /// <returns>Retourne une liste d'objets <see cref="EveryDTO"/> contenant les informations complètes.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EveryDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            IEnumerable<EveryDTO>? result = await _dokiHouseBLLService.GetInfos(cancellationToken);

            return
                result is not null
                ? Ok(result)
                : NoContent();
        }



        /// <summary>
        /// Obtient les informations paginées sur les utilisateurs avec leurs bonsaïs, catégories, styles et notes associés.
        /// </summary>
        /// <param name="startIndex">Index de départ pour la pagination.</param>
        /// <param name="pageSize">Taille de la page pour la pagination.</param>
        /// <param name="cancellationToken">Token d'annulation pour arrêter la requête de manière asynchrone si nécessaire.</param>
        /// <returns>Retourne une liste paginée d'objets <see cref="EveryDTO"/> contenant les informations complètes.</returns>
        [HttpGet(nameof(GetPageSize))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EveryDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetPageSize([FromQuery] int startIndex, [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            if (startIndex < 1 || pageSize < 1)
                return BadRequest("La page et la taille de la page doivent être des valeurs positives.");

            startIndex--;

            IEnumerable<EveryDTO>? result = await _dokiHouseBLLService.GetInfosPaginated(startIndex, pageSize, cancellationToken);

            return
                result is not null
                ? Ok(result)
                : NoContent();
        }

    }
}
