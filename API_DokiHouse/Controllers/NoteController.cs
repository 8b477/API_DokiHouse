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


        [HttpPost("{idBonsai}:int")]
        public async Task<IActionResult> Create(int idBonsai, NoteModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            NoteBLL note = Mapper.NoteModelToBLL(model);

            note.IdBonsai = idBonsai;

            return
                await _noteService.CreateNote(note)
                ? Ok()
                : BadRequest();
        }


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
    }
}
