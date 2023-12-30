using API_DokiHouse.Models;
using API_DokiHouse.Services;
using BLL_DokiHouse.Interfaces;
using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Tools_DokiHouse.Filters.JwtIdentifiantFilter;

namespace API_DokiHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        #region Injection
        private readonly IUserBLLService _userService;

        public UserController(IUserBLLService userService, IPictureRepo pictureRepo)
        {
            _userService = userService;
        }
        #endregion


        /// <summary>
        /// Récupère la liste des utilisateurs.
        /// </summary>
        /// <remarks>
        /// Cette méthode permet de récupérer la liste complète des utilisateurs.
        /// </remarks>
        /// <response code="200">Retourne la liste des utilisateurs.</response>
        /// <response code="204">Aucun utilisateur n'est trouvé.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserDisplayDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            IEnumerable<UserDisplayDTO>? result = await _userService.Get();

            if (result is not null)
                return Ok(result);

            return NoContent();
        }


        /// <summary>
        /// Récupère un utilisateur par ID.
        /// </summary>
        /// <remarks>
        /// Cette méthode permet de récupérer un utilisateur spécifique en utilisant son ID.
        /// </remarks>
        /// <param name="id">L'identifiant de l'utilisateur.</param>
        /// <response code="200">Retourne l'utilisateur trouvé.</response>
        /// <response code="204">Aucun utilisateur n'est trouvé.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDisplayDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            UserDisplayDTO? result = await _userService.GetByID(id);

            if (result is not null)
                return Ok(result);

            return NoContent();
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserDisplayDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetByName([FromRoute] string name)
        {
            IEnumerable<UserDisplayDTO>? result = await _userService.GetByName(name);

            if (result is not null)
                return Ok(result);

            return NoContent();
        }


        /// <summary>
        /// Crée un nouvel utilisateur.
        /// </summary>
        /// <remarks>
        /// Cette méthode permet de créer un nouvel utilisateur en utilisant les informations fournies.
        /// </remarks>
        /// <param name="model">Les informations de l'utilisateur à créer.</param>
        /// <response code="201">Retourne les informations de l'utilisateur créé.</response>
        /// <response code="400">La création de l'utilisateur a échoué.</response>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserPassConfirmModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] UserPassConfirmModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            UserCreateDTO user = Mapper.FromConfirmPassToModelCreate(model);

            return await _userService.Create(user) == true 
                ? CreatedAtAction(nameof(Create), model) 
                : BadRequest();
        }


        /// <summary>
        /// Met à jour un utilisateur.
        /// </summary>
        /// <remarks>
        /// Cette méthode permet de mettre à jour un utilisateur existant en utilisant son ID et les nouvelles informations fournies.
        /// </remarks>
        /// <param name="id">L'identifiant de l'utilisateur à mettre à jour.</param>
        /// <param name="model">Les nouvelles informations de l'utilisateur.</param>
        /// <response code="200">Retourne les informations de l'utilisateur mis à jour.</response>
        /// <response code="400">La mise à jour de l'utilisateur a échoué.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserUpdateModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UserUpdateModel model)
        {
            UserCreateDTO? user = Mapper.FromUpdateToModelCreate(model);

            if(await _userService.Update(id, user))           
                return Ok(user);

            return BadRequest();
        }


        /// <summary>
        /// Supprime un utilisateur en fonction de son identifiant.
        /// </summary>
        /// <remarks>
        /// Cette méthode permet de supprimer un utilisateur existant en utilisant son identifiant.
        /// </remarks>
        /// <param name="id">L'identifiant de l'utilisateur à supprimer.</param>
        /// <response code="204">L'utilisateur a été supprimé avec succès.</response>
        /// <response code="400">La suppression de l'utilisateur a échoué.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            return await _userService.Delete(id) == true ? NoContent() : BadRequest("Aucune correspondance");
        }

    }
}
