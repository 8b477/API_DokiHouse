using API_DokiHouse.Models;
using BLL_DokiHouse.Interfaces;


using Microsoft.AspNetCore.Mvc;

namespace API_DokiHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StyleController : ControllerBase
    {

        #region Injection

        private readonly IStyleBLLService _styleService;

        public StyleController(IStyleBLLService styleService) => _styleService = styleService;

        #endregion


        /// <summary>
        /// Crée un nouveau style pour un bonsaï spécifié.
        /// </summary>
        /// <param name="idBonsai">Identifiant du bonsaï pour lequel le style est créé.</param>
        /// <param name="style">Modèle du style à créer.</param>
        /// <returns>
        /// Une action HTTP avec le statut CreatedAtAction et le modèle créé si la création réussit,
        /// sinon BadRequest.
        /// </returns>
        [HttpPost("{idBonsai:int}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(StyleModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Create(int idBonsai, StyleModel style)
        {
            if (!ModelState.IsValid) return BadRequest();

            return
                await _styleService.CreateStyle(idBonsai, style)
                ? CreatedAtAction(nameof(Create), style)
                : BadRequest();
        }


        /// <summary>
        /// Met à jour les informations d'un style pour un bonsaï spécifié.
        /// </summary>
        /// <param name="idBonsai">Identifiant du bonsaï pour lequel le style est mis à jour.</param>
        /// <param name="style">Modèle contenant les nouvelles informations du style.</param>
        /// <returns>
        /// Une action HTTP avec le statut Ok si la mise à jour réussit, sinon BadRequest.
        /// </returns>
        [HttpPut("{idBonsai:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update(int idBonsai, StyleModel style)
        {
            if (!ModelState.IsValid) return BadRequest();

            return
                await _styleService.UpdateStyle(idBonsai, style)
                ? Ok()
                : BadRequest();
        }


        /// <summary>
        /// Supprime un style présent en base de donnée sur base de son id.
        /// </summary>
        /// <param name="idStyle">Identifiant de type INT</param>
        /// <returns>
        /// Une action HTTP avec le statut NoContent si la suppression réussit, sinon BadRequest.
        /// </returns>
        [HttpDelete("{idStyle:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(int idStyle)
        {
            return
                await _styleService.DeleteStyle(idStyle)
                ? NoContent()
                : BadRequest();
        }

    }
}
