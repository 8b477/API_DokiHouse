using API_DokiHouse.Models;
using API_DokiHouse.Services;

using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Models;

using DAL_DokiHouse.DTO;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_DokiHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {  
        #region Injection

        private readonly ICategoryBLLService _categoryService;

        public CategoryController(ICategoryBLLService categoryService)
        {
            _categoryService = categoryService;
        }

        #endregion


        [HttpPost("{idBonsai}:int")]
        public async Task<IActionResult> Create([FromRoute] int idBonsai ,CategoryModel model)
        {
            CategoryBLL categoryBLL = Mapper.CategoryModelToBLL(model);

            categoryBLL.IdBonsai = idBonsai;

            if (categoryBLL.IdBonsai == 0)
                return BadRequest("L'idBonsai n'est pas correct");

            if (await _categoryService.Create(idBonsai, categoryBLL)) return Ok();

            return BadRequest();
        }
    }
}
