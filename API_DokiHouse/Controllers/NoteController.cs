using API_DokiHouse.Models;
using API_DokiHouse.Services;
using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Models;

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
        /// Retourne une action HTTP indiquant le succès ou l'échec de la création de la note.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Create(int idBonsai, NoteModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            NoteBLL note = Mapper.NoteModelToBLL(model);

            note.IdBonsai = idBonsai;

            return
                await _noteService.CreateNote(note)
                ? CreatedAtAction(nameof(Create),model)
                : BadRequest();
        }


        /// <summary>
        /// Met à jour les informations d'une note pour un bonsaï spécifié.
        /// </summary>
        /// <param name="idBonsai">Identifiant du bonsaï pour lequel la note est mise à jour.</param>
        /// <param name="model">Modèle contenant les nouvelles informations de la note.</param>
        /// <returns>
        /// Retourne une action HTTP indiquant le succès ou l'échec de la mise à jour de la note.
        /// </returns>
        [HttpPut("{idBonsai}:int")]
        public async Task<IActionResult> Update(int idBonsai, NoteModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            NoteBLL note = Mapper.NoteModelToBLL(model);

            note.IdBonsai = idBonsai;

            return
                await _noteService.UpdateNote(note)
                ? Ok()
                : BadRequest();
        }


        /// <summary>
        /// Supprime une note sur base de son identifiant
        /// </summary>
        /// <param name="id">Son identifiant de type : 'int'</param>
        /// <returns>Retourne True si la suppression à réussie si non retourne False</returns>
        [HttpDelete("{id}:int")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _noteService.DeleteNote(id) ? NoContent() : BadRequest("La suppression de la note à échouer");
        }
    }
}
