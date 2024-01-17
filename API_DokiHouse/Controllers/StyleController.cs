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
        /// Retourne une action HTTP indiquant le succès ou l'échec de la création du style.
        /// </returns>
        [HttpPost("{idBonsai:int}")]
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
        /// Retourne une action HTTP indiquant le succès ou l'échec de la mise à jour du style.
        /// </returns>
        [HttpPut("{idBonsai:int}")]
        public async Task<IActionResult> Update(int idBonsai, StyleModel style)
        {
            if (!ModelState.IsValid) return BadRequest();

            return
                await _styleService.UpdateStyle(idBonsai, style)
                ? Ok()
                : BadRequest();
        }


        /// <summary>
        /// Permet la suppression d'un style présent en base de donnée sur base de son id.
        /// </summary>
        /// <param name="idStyle">Identifiant de type INT</param>
        /// Retourne une action HTTP indiquant le succès ou l'échec de la suppression du style ciblé.
        [HttpDelete("{idStyle:int}")]
        public async Task<IActionResult> Delete(int idStyle)
        {
            return
                await _styleService.DeleteStyle(idStyle)
                ? NoContent()
                : BadRequest();
        }
    }
}
