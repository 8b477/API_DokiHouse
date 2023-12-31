﻿using API_DokiHouse.Models;
using API_DokiHouse.Services;
using API_DokiHouse.Tools;
using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Models;
using DAL_DokiHouse.DTO;
using Tools_DokiHouse.Filters.JwtIdentifiantFilter;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API_DokiHouse.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(JwtUserIdentifiantFilter))]
    [ApiController]
    public class UserController : ControllerBase
    {

        #region Injection
        private readonly IUserBLLService _userService;
        private readonly GetInfosHTTPContext _httpContextService;

        public UserController(IUserBLLService userService, GetInfosHTTPContext httpContextService)
        {
            _userService = userService;
            _httpContextService = httpContextService;
        }
        #endregion



        /// <summary>
        /// Crée un nouvel utilisateur.
        /// </summary>
        /// <remarks>
        /// Cette méthode permet de créer un nouvel utilisateur en utilisant les informations fournies.
        /// </remarks>
        /// <param name="model">Les informations de l'utilisateur à créer.</param>
        /// <response code="201">La création de l'utilisateur à réusi.</response>
        /// <response code="400">La création de l'utilisateur a échoué.</response>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserBLL))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] UserCreateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            UserBLL user = Mapper.UserModelToBLL(model);

            return
                await _userService.CreateUser(user) == true
                ? CreatedAtAction(nameof(Create),null)
                : BadRequest();
        }



        /// <summary>
        /// Récupère la liste des utilisateurs.
        /// </summary>
        /// <remarks>
        /// Cette méthode permet de récupérer la liste complète des utilisateurs.
        /// </remarks>
        /// <response code="200">Retourne la liste des utilisateurs.</response>
        /// <response code="204">Aucun utilisateur n'est trouvé.</response>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserModelDisplay>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            IEnumerable<UserDTO?> result = await _userService.Get();

            if (result is not null)
                return Ok(Mapper.UserBLLToFormatDisplay(result));

            return NoContent();
        }



        /// <summary>
        /// Récupère un utilisateur par ID.
        /// </summary>
        /// <remarks>
        /// Cette méthode permet de à l'utilisateur de consulter son profil.
        /// </remarks>
        /// <response code="200">Retourne l'utilisateur trouvé.</response>
        /// <response code="204">Aucun utilisateur n'est trouvé.</response>
        [HttpGet("Profil")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserModelDisplay))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById()
        {
            int idUser = _httpContextService.GetLoggedInUserId();

            if (idUser == 0) return Unauthorized();

            UserDTO? result = await _userService.GetByID(idUser);

            if (result is not null)
                return Ok(Mapper.UserBLLToFormatDisplay(result));

            return BadRequest("Aucune correspondance");
        }



        /// <summary>
        /// Récupère un utilisateur par nom.
        /// </summary>
        /// <remarks>
        /// Cette méthode permet de récupérer une liste d'utilisateurs en utilisant leur nom.
        /// </remarks>
        /// <param name="name">Le nom de l'utilisateur.</param>
        /// <response code="200">Retourne la liste des utilisateurs trouvés.</response>
        /// <response code="204">Aucun utilisateur n'est trouvé.</response>
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserModelDisplay>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetByName([FromRoute] string name)
        {
            IEnumerable<UserDTO?> result = await _userService.GetByName(name);

            if (result is not null)
                return Ok(Mapper.UserBLLToFormatDisplay(result));

            return NoContent();
        }



        /// <summary>
        /// Met à jour le profil d'un utilisateur.
        /// </summary>
        /// <remarks>
        /// Cette méthode permet de mettre à jour le nom d'un utilisateur existant en utilisant son ID et les nouvelles informations fournies.
        /// </remarks>
        /// <param name="model">Les nouvelles informations de l'utilisateur.</param>
        /// <response code="200">Retourne les informations de l'utilisateur mis à jour.</response>
        /// <response code="400">La mise à jour de l'utilisateur a échoué.</response>
        [HttpPut(nameof(Name))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserNameUpdateModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Name([FromBody] UserNameUpdateModel model)
        {         
            int idUser = _httpContextService.GetLoggedInUserId();

            if (idUser == 0) return Unauthorized();

            UserUpdateNameBLL user = Mapper.UserModelToBLL(model);

            if(await _userService.UpdateUserName(idUser, user))           
                return Ok();

            return BadRequest();
        }



        /// <summary>
        /// Met à jour le profil d'un utilisateur.
        /// </summary>
        /// <remarks>
        /// Cette méthode permet de mettre à jour le mot de passe d'un utilisateur existant en utilisant son ID et les nouvelles informations fournies.
        /// </remarks>
        /// <param name="model">Les nouvelles informations de l'utilisateur.</param>
        /// <response code="200">Retourne les informations de l'utilisateur mis à jour.</response>
        /// <response code="400">La mise à jour de l'utilisateur a échoué.</response>
        [HttpPut(nameof(Pass))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserPassUpdateModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Pass([FromBody] UserPassUpdateModel model)
        {
            int idUser = _httpContextService.GetLoggedInUserId();

            if (idUser == 0) return Unauthorized();

            UserUpdatePassBLL user = Mapper.UserModelToBLL(model);

            if (await _userService.UpdateUserPass(idUser, user))
                return Ok();

            return BadRequest();
        }



        /// <summary>
        /// Met à jour le profil d'un utilisateur.
        /// </summary>
        /// <remarks>
        /// Cette méthode permet de mettre à jour l'email d'un utilisateur existant en utilisant son ID et les nouvelles informations fournies.
        /// </remarks>
        /// <param name="model">Les nouvelles informations de l'utilisateur.</param>
        /// <response code="200">Retourne les informations de l'utilisateur mis à jour.</response>
        /// <response code="400">La mise à jour de l'utilisateur a échoué.</response>
        [HttpPut(nameof(Mail))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserMailUpdateModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Mail([FromBody] UserMailUpdateModel model)
        {
            int idUser = _httpContextService.GetLoggedInUserId();

            if (idUser == 0) return Unauthorized();

            UserUpdateMailBLL user = Mapper.UserModelToBLL(model);

            if (await _userService.UpdateUserEmail(idUser, user))
                return Ok();

            return BadRequest();
        }



        /// <summary>
        /// Supprime un utilisateur en fonction de son identifiant.
        /// </summary>
        /// <remarks>
        /// Cette méthode permet de supprimer un utilisateur existant en utilisant son identifiant.
        /// </remarks>
        /// <response code="204">L'utilisateur a été supprimé avec succès.</response>
        /// <response code="400">La suppression de l'utilisateur a échoué.</response>
        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete()
        {
            int idUser = _httpContextService.GetLoggedInUserId();

            if(idUser == 0) return Unauthorized();

            return 
                await _userService.DeleteUser(idUser) == true
                ? NoContent() 
                : BadRequest("Aucune correspondance");
        }

    }
}
