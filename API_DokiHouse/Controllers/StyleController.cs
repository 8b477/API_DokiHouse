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



        [HttpPost("{idBonsai}:int")]
        public async Task<IActionResult> Create(int idBonsai, StyleModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            StyleBLL style = Mapper.StyleModelToBLL(model);

            style.IdBonsai = idBonsai;         

            return
                await _styleService.CreateStyle(style)
                ? Ok()
                : BadRequest();
        }



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
