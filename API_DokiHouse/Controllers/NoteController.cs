using API_DokiHouse.Models;
using BLL_DokiHouse.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API_DokiHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {

        #region Injection

        private readonly INoteBLLService _noteService;

        public NoteController(INoteBLLService noteService) => _noteService = noteService;

        #endregion


        /// <summary>
        /// Crée une nouvelle note pour un bonsaï spécifié.
        /// </summary>
        /// <param name="idBonsai">Identifiant du bonsaï pour lequel la note est créée.</param>
        /// <param name="model">Modèle de la note à créer.</param>
        /// <returns>
        /// Retourne un résultat HTTP indiquant le succès ou l'échec de la création de la note.
        /// </returns>
        /// <response code="201">La note a été créée avec succès. Retourne l'objet créé.</response>
        /// <response code="400">La création de la note a échoué en raison de données invalides. Le message explicatif est fourni dans le corps de la réponse.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(NoteModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Create(int idBonsai, NoteModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            return await _noteService.CreateNote(idBonsai, model)
                ? CreatedAtAction(nameof(Create), model)
                : BadRequest();
        }


        /// <summary>
        /// Met à jour les informations d'une note pour un bonsaï spécifié.
        /// </summary>
        /// <param name="idNote">Identifiant de la note à mettre à jour.</param>
        /// <param name="model">Modèle contenant les nouvelles informations de la note.</param>
        /// <returns>
        /// Retourne un résultat HTTP indiquant le succès ou l'échec de la mise à jour de la note.
        /// </returns>
        /// <response code="200">La note a été mise à jour avec succès.</response>
        /// <response code="400">La mise à jour de la note a échoué en raison de données invalides. Le message explicatif est fourni dans le corps de la réponse.</response>
        [HttpPut("{idNote:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update(int idNote, NoteModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return await _noteService.UpdateNote(idNote, model)
                ? Ok()
                : BadRequest();
        }


        /// <summary>
        /// Supprime une note sur base de son identifiant.
        /// </summary>
        /// <param name="id">Son identifiant de type : 'int'</param>
        /// <returns>
        /// Retourne un résultat HTTP indiquant le succès ou l'échec de la suppression de la note.
        /// </returns>
        /// <response code="204">La note a été supprimée avec succès.</response>
        /// <response code="400">La suppression de la note a échoué. Le message explicatif est fourni dans le corps de la réponse.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(int id)
        {
            return await _noteService.DeleteNote(id) ? NoContent() : BadRequest("La suppression de la note a échoué");
        }


    }
}
