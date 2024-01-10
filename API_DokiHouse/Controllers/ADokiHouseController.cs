﻿using BLL_DokiHouse.Interfaces;
using DAL_DokiHouse.DTO;

using Microsoft.AspNetCore.Authorization;
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
        [HttpGet(nameof(GetUsersAndBonsaisDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EveryDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetUsersAndBonsaisDetails(CancellationToken cancellationToken)
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
        /// <param name="startIndex">Index de départ pour la pagination si pas renseignée valeur par défaut => '1'.</param>
        /// <param name="pageSize">Taille de la page pour la pagination si pas renseignée valeur par défaut => '12'.</param>
        /// <param name="cancellationToken">Token d'annulation pour arrêter la requête de manière asynchrone si nécessaire.</param>
        /// <returns>Retourne une liste paginée d'objets <see cref="EveryDTO"/> contenant les informations complètes.</returns>
        [HttpGet(nameof(GetBonsaispaginated))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EveryDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetBonsaispaginated(CancellationToken cancellationToken, [FromQuery] int startIndex = 1, [FromQuery] int pageSize = 12)
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


        /// <summary>
        /// Obtient les informations complètes sur les utilisateurs avec leurs Posts et commentaires associés.
        /// </summary>
        /// <param name="cancellationToken">Token d'annulation pour arrêter la requête de manière asynchrone si nécessaire.</param>
        /// <returns>Retourne une liste d'objets <see cref="BlogDTO"/> contenant les informations complètes.</returns>
        [AllowAnonymous]
        [HttpGet(nameof(GetBlogs))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BlogDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetBlogs(CancellationToken cancellationToken)
        {
            var result = await _dokiHouseBLLService.InfosTest(cancellationToken);

            return
                result is not null
                ? Ok(result)
                : NoContent();
        }
    }
}
