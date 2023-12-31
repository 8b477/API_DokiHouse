﻿using API_DokiHouse.Models;
using API_DokiHouse.Services;
using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Models;

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


        /// <summary>
        /// Crée une nouvelle catégorie pour un bonsaï spécifié.
        /// </summary>
        /// <param name="idBonsai">Identifiant du bonsaï pour lequel la catégorie est créée.</param>
        /// <param name="model">Modèle de la catégorie à créer.</param>
        /// <returns>
        /// Retourne une action HTTP indiquant le succès ou l'échec de la création de la catégorie.
        /// </returns>
        [HttpPost("{idBonsai}:int")]
        public async Task<IActionResult> Create([FromRoute] int idBonsai, CategoryModel model)
        {
            CategoryBLL categoryBLL = Mapper.CategoryModelToBLL(model);

            categoryBLL.IdBonsai = idBonsai;

            if (categoryBLL.IdBonsai == 0)
                return BadRequest("L'idBonsai n'est pas correct");

            if (await _categoryService.Create(idBonsai, categoryBLL)) return Ok();

            return BadRequest();
        }


        /// <summary>
        /// Met à jour les informations d'une catégorie pour un bonsaï spécifié.
        /// </summary>
        /// <param name="idBonsai">Identifiant du bonsaï pour lequel la catégorie est mise à jour.</param>
        /// <param name="model">Modèle contenant les nouvelles informations de la catégorie.</param>
        /// <returns>
        /// Retourne une action HTTP indiquant le succès ou l'échec de la mise à jour de la catégorie.
        /// </returns>
        [HttpPut("{idBonsai}:int")]
        public async Task<IActionResult> Update([FromRoute] int idBonsai, [FromBody] CategoryModel model)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CategoryBLL category = Mapper.CategoryModelToBLL(model);

            category.IdBonsai = idBonsai;

            return
                await _categoryService.Update(category)
                ? Ok()
                : BadRequest();
        }
    }
}
