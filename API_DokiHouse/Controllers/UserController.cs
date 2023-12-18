using API_DokiHouse.Services;
using BLL_DokiHouse.Interfaces;
using DAL_DokiHouse.DTO;

using Microsoft.AspNetCore.Mvc;

namespace API_DokiHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        #region Injection
        private readonly IUserBLLService _userService;

        public UserController(IUserBLLService userService)
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
        public async Task<IActionResult> GetById(int id)
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
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserCreateDTOPassConfirm))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(UserCreateDTOPassConfirm model)
        {
            UserCreateDTO user = Mapper.ToModelCreate(model);

            if (await _userService.Create(user) && model is not null)
            {
                return CreatedAtAction(nameof(Create), model);
            }

            return BadRequest();
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserCreateDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, UserCreateDTO model)
        {
            UserCreateDTO? user = await _userService.Update(id, model);

            if (user is not null)
                return Ok(user);

            return BadRequest();
        }
    }
}
