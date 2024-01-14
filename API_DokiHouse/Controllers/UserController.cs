using API_DokiHouse.Models;
using API_DokiHouse.Services;
using API_DokiHouse.Tools;
using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Models;
using Tools_DokiHouse.Filters.JwtIdentifiantFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DAL_DokiHouse.Repository;
using BLL_DokiHouse.Models.User;
using DAL_DokiHouse.DTO.User;



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

            return
                await _userService.CreateUser(model) == true
                ? CreatedAtAction(nameof(Create),model)
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserAndPictureDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get([FromQuery] int startIndex = 1, [FromQuery] int pageSize = 12)
        {
            if (startIndex < 1) return BadRequest("Le paramètre startIndex doit être supérieur à zéro");
            if (pageSize < 1) return BadRequest("Le paramètre pageSize doit être supérieur à zéro");

            startIndex--;

            IEnumerable<UserAndPictureDTO?> result = await _userService.GetUsers(startIndex, pageSize);

            return result is not null 
                   ? Ok(result)
                   : NoContent();
        }


        /// <summary>
        /// Récupère la liste des utilisateurs avec leurs infos bonsais.
        /// </summary>
        /// <remarks>
        /// Cette méthode permet de récupérer la liste complète des utilisateurs sur base d'une pagination.
        /// </remarks>
        /// <param name="startIndex">Représente l'index de départ, param de type : 'int', valeur par défaut : 1</param>
        /// <param name="pageSize">Représente le nombre d'utilisateur à récupérer, param de type : 'int', valeur par défaut : 12</param>
        /// <response code="200">Retourne la liste des utilisateurs.</response>
        /// <response code="204">Aucun utilisateur n'est trouvé.</response>
        /// <response code="400">La requête n'est pas correct.</response>
        [HttpGet(nameof(GetInfos))]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserDetailsBonsaiDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetInfos([FromQuery] int startIndex = 1, [FromQuery] int pageSize = 12)
        {
            if (startIndex < 1) return BadRequest("Le paramètre startIndex doit être supérieur à zéro");
            if (pageSize < 1) return BadRequest("Le paramètre pageSize doit être supérieur à zéro");

            startIndex--;

            IEnumerable<UserDetailsBonsaiDTO?> result = await _userService.GetInfos(startIndex, pageSize);
          
            return result is null 
                ? NoContent() 
                : Ok(result);
        }


        /// <summary>
        /// Récupère un utilisateur sur base de son identifiant de type int et ses bonsais.
        /// </summary>
        /// <param name="idUser">Représente l'identifiant de l'utilisateur rechercher, param de type : 'int'</param>
        /// <response code="200">Retourne un utilisateur.</response>
        /// <response code="204">Aucun utilisateur n'est trouvé.</response>
        /// <response code="400">La requête n'est pas correct.</response>
        [HttpGet(nameof(GetInfosById))]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDetailsBonsaiDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetInfosById(int idUser)
        {
            UserDetailsBonsaiDTO? result = await _userService.GetInfosById(idUser);

            return result is null
                ? NoContent()
                : Ok(result);
        }


        /// <summary>
        /// Consulte le profil de l'utilisateur préalablement log.
        /// </summary>
        /// <remarks>
        /// Cette méthode permet de à l'utilisateur de consulter son profil.
        /// </remarks>
        /// <response code="200">Retourne l'utilisateur trouvé.</response>
        /// <response code="204">Aucun utilisateur n'est trouvé.</response>
        [HttpGet(nameof(Profil))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserModelDisplay))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Profil()
        {
            int idUser = _httpContextService.GetIdUserTokenInHttpContext();

            if (idUser == 0) return Unauthorized();

            UserDTO? result = await _userService.GetUserByID(idUser);

            if (result is not null)
                return Ok(Mapper.UserBLLToFormatDisplay(result));

            return NoContent();
        }


        /// <summary>
        /// Récupère un utilisateur par nom.
        /// </summary>
        /// <remarks>
        /// Cette méthode permet de récupérer une liste d'utilisateurs en utilisant leur nom.
        /// </remarks>
        /// <param name="name">Le nom de l'utilisateur.</param>
        /// <param name="stringIdentifiant">Le nom de la colonne en DB a comparé avec la recherche, par défaut ça valeur est : 'Name'.</param>
        /// <response code="200">Retourne la liste des utilisateurs trouvés.</response>
        /// <response code="204">Aucun utilisateur n'est trouvé.</response>
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserModelDisplay>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetByName([FromRoute] string name, string stringIdentifiant = "Name")
        {
            IEnumerable<UserDTO?> result = await _userService.GetUsersByName(name,stringIdentifiant);

            if (result is not null)
                return Ok(Mapper.UserBLLToFormatDisplay(result));

            return NoContent();
        }


        /// <summary>
        /// Met à jour le profil complet d'un utilisateur.
        /// </summary>
        /// <remarks>
        /// Cette méthode permet de mettre à jour le nom d'un utilisateur existant en utilisant son ID et les nouvelles informations fournies.
        /// </remarks>
        /// <param name="model">Les nouvelles informations de l'utilisateur.</param>
        /// <response code="200">Retourne les informations de l'utilisateur mis à jour.</response>
        /// <response code="400">La mise à jour de l'utilisateur a échoué.</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] UserUpdateModel model)
        {
            int idUser = _httpContextService.GetIdUserTokenInHttpContext();

            if (idUser == 0) return Unauthorized();

            UserUpdateBLL user = Mapper.UserUpdateModelToBLL(model);

            if (await _userService.UpdateUser(idUser, user))
                return Ok();

            return BadRequest();
        }


        /// <summary>
        /// Met à jour le nom du profil d'un utilisateur.
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
            int idUser = _httpContextService.GetIdUserTokenInHttpContext();

            if (idUser == 0) return Unauthorized();

            UserUpdateNameBLL user = Mapper.UserModelToBLL(model);

            if(await _userService.UpdateUserName(idUser, user))           
                return Ok(model);

            return BadRequest();
        }


        /// <summary>
        /// Met à jour le mot de passe du profil d'un utilisateur.
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
            int idUser = _httpContextService.GetIdUserTokenInHttpContext();

            if (idUser == 0) return Unauthorized();

            UserUpdatePassBLL user = Mapper.UserModelToBLL(model);

            if (await _userService.UpdateUserPass(idUser, user))
                return Ok(model);

            return BadRequest();
        }


        /// <summary>
        /// Met à jour le mail du profil d'un utilisateur.
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
            int idUser = _httpContextService.GetIdUserTokenInHttpContext();

            if (idUser == 0) return Unauthorized();

            UserUpdateMailBLL user = Mapper.UserModelToBLL(model);

            if (await _userService.UpdateUserEmail(idUser, user))
                return Ok(model);

            return BadRequest();
        }


        /// <summary>
        /// Supprime un utilisateur préalablement log.
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
            int idUser = _httpContextService.GetIdUserTokenInHttpContext();

            if(idUser == 0) return Unauthorized();

            return 
                await _userService.DeleteUser(idUser) == true
                ? NoContent() 
                : BadRequest("Aucune correspondance");
        }

    }
}
