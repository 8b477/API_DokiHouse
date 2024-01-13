using API_DokiHouse.Models;
using API_DokiHouse.Services;
using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Models;

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
        /// <param name="model">Modèle du style à créer.</param>
        /// <returns>
        /// Retourne une action HTTP indiquant le succès ou l'échec de la création du style.
        /// </returns>
        [HttpPost("{idBonsai}:int")]
        public async Task<IActionResult> Create(int idBonsai, StyleModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            StyleBLL style = Mapper.StyleModelToBLL(model);

            style.IdBonsai = idBonsai;         

            return
                await _styleService.CreateStyle(style)
                ? CreatedAtAction(nameof(Create),model)
                : BadRequest();
        }


        /// <summary>
        /// Met à jour les informations d'un style pour un bonsaï spécifié.
        /// </summary>
        /// <param name="idBonsai">Identifiant du bonsaï pour lequel le style est mis à jour.</param>
        /// <param name="model">Modèle contenant les nouvelles informations du style.</param>
        /// <returns>
        /// Retourne une action HTTP indiquant le succès ou l'échec de la mise à jour du style.
        /// </returns>
        [HttpPut("{idBonsai}:int")]
        public async Task<IActionResult> Update(int idBonsai, StyleModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            StyleBLL style = Mapper.StyleModelToBLL(model);

            style.IdBonsai = idBonsai;

            return
                await _styleService.UpdateStyle(style)
                ? Ok()
                : BadRequest();
        }
    }
}
