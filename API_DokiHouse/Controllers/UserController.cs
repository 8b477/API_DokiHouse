using API_DokiHouse.Tools;
using BLL_DokiHouse.Interfaces;
using Tools_DokiHouse.Filters.JwtIdentifiantFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BLL_DokiHouse.Models.User;
using DAL_DokiHouse.DTO.User;
using Entities_DokiHouse.Entities;
using BLL_DokiHouse.Models.User.View;
using BLL_DokiHouse.ExceptionHandler;



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
        /// <response code="201">La création de l'utilisateur à réussi.</response>
        /// <response code="400">La création de l'utilisateur a échoué.</response>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserView))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Create([FromBody] UserCreateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            UserView? userView = await _userService.CreateUser(model);

            return
                  userView is null
                ? BadRequest()
                : CreatedAtAction(nameof(Create), userView);
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserAndPictureDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
        /// Récupère un utilisateur sur base de son identifiant.
        /// </summary>
        /// <remarks>
        /// Cette méthode permet de récupérer la liste complète des utilisateurs.
        /// </remarks>
        /// <response code="200">Retourne la liste des utilisateurs.</response>
        /// <response code="204">Aucun utilisateur n'est trouvé.</response>
        [HttpGet("{idUser:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserAndPictureDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Get(int idUser)
        {
            UserAndPictureDTO? result = await _userService.GetUser(idUser);

            return result is not null
                   ? Ok(result)
                   : NoContent();
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserView))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Profil()
        {
            int idUser = _httpContextService.GetIdUserTokenInHttpContext();

            if (idUser == 0) return Unauthorized();

            UserView? result = await _userService.GetUserByID(idUser);

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
        /// <param name="stringIdentifiant">Le nom de la colonne en DB a comparé avec la recherche, par défaut ça valeur est : 'Name'.</param>
        /// <response code="200">Retourne la liste des utilisateurs trouvés.</response>
        /// <response code="204">Aucun utilisateur n'est trouvé.</response>
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<User>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetByName([FromRoute] string name, string stringIdentifiant = "Name")
        {
            IEnumerable<User?> result = await _userService.GetUsersByName(name,stringIdentifiant);

            if (result is not null)
                return Ok(result);

            return NoContent();
        }


        /// <summary>
        /// Met à jour le profil complet d'un utilisateur.
        /// </summary>
        /// <remarks>
        /// Cette méthode permet de mettre à jour le nom d'un utilisateur existant en utilisant son ID et les nouvelles informations fournies.
        /// </remarks>
        /// <param name="user">Les nouvelles informations de l'utilisateur.</param>
        /// <response code="200">Retourne les informations de l'utilisateur mis à jour.</response>
        /// <response code="400">La mise à jour de l'utilisateur a échoué.</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UserUpdateModel user)
        {
            int idUser = _httpContextService.GetIdUserTokenInHttpContext();

            if (idUser == 0) return Unauthorized();

            if (await _userService.UpdateUser(idUser, user))
                return Ok("A successful update");

            return BadRequest();
        }


        /// <summary>
        /// Met à jour le nom du profil d'un utilisateur.
        /// </summary>
        /// <remarks>
        /// Cette méthode permet de mettre à jour le nom d'un utilisateur existant en utilisant son ID et les nouvelles informations fournies.
        /// </remarks>
        /// <param name="user">Les nouvelles informations de l'utilisateur.</param>
        /// <response code="200">Retourne les informations de l'utilisateur mis à jour.</response>
        /// <response code="400">La mise à jour de l'utilisateur a échoué.</response>
        [HttpPut(nameof(Name))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Name([FromBody] UserUpdateNameModel user)
        {         
            int idUser = _httpContextService.GetIdUserTokenInHttpContext();

            if (idUser == 0) return Unauthorized();

            if(await _userService.UpdateUserName(idUser, user))
            {              
                return Ok(user);
            }           

            return BadRequest();
        }


        /// <summary>
        /// Met à jour le mot de passe du profil d'un utilisateur.
        /// </summary>
        /// <remarks>
        /// Cette méthode permet de mettre à jour le mot de passe d'un utilisateur existant en utilisant son ID et les nouvelles informations fournies.
        /// </remarks>
        /// <param name="user">Les nouvelles informations de l'utilisateur.</param>
        /// <response code="200">Retourne les informations de l'utilisateur mis à jour.</response>
        /// <response code="400">La mise à jour de l'utilisateur a échoué.</response>
        [HttpPut(nameof(Pass))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Pass([FromBody] UserUpdatePasswdModel user)
        {
            int idUser = _httpContextService.GetIdUserTokenInHttpContext();

            if (idUser == 0) return Unauthorized();

            if (await _userService.UpdateUserPass(idUser, user))
            {
                return Ok(true);
            }

            return BadRequest(false);
        }


        /// <summary>
        /// Met à jour le mail du profil d'un utilisateur.
        /// </summary>
        /// <remarks>
        /// Cette méthode permet de mettre à jour l'email d'un utilisateur existant en utilisant son ID et les nouvelles informations fournies.
        /// </remarks>
        /// <param name="user">Les nouvelles informations de l'utilisateur.</param>
        /// <response code="200">Retourne les informations de l'utilisateur mis à jour.</response>
        /// <response code="400">La mise à jour de l'utilisateur a échoué.</response>
        [HttpPut(nameof(Mail))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Mail([FromBody] UserUpdateEmailModel user)
        {
            int idUser = _httpContextService.GetIdUserTokenInHttpContext();

            if (idUser == 0) return Unauthorized();

            if (await _userService.UpdateUserEmail(idUser, user))
                return Ok("Mail Update");

            return BadRequest();
        }


        /// <summary>
        /// Supprime un utilisateur sur base d'un identifiant.
        /// </summary>
        /// <remarks>
        /// Cette méthode permet de supprimer un utilisateur existant en utilisant son identifiant.
        /// </remarks>
        /// <param name="idUser">Identifiant de l'utilisateur de type INT</param>
        /// <response code="204">L'utilisateur a été supprimé avec succès.</response>
        /// <response code="400">La suppression de l'utilisateur a échoué.</response>
        [HttpDelete("{idUser:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Delete(int idUser)
        {           
            return
                await _userService.DeleteUser(idUser) == true
                ? NoContent()
                : BadRequest("Aucune correspondance");
        }


        /// <summary>
        /// Supprime un utilisateur préalablement log.
        /// </summary>
        /// <remarks>
        /// Cette méthode permet de supprimer un utilisateur existant en utilisant son identifiant.
        /// </remarks>
        /// <response code="204">L'utilisateur a été supprimé avec succès.</response>
        /// <response code="400">La suppression de l'utilisateur a échoué.</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Delete()
        {
            int idUser = _httpContextService.GetIdUserTokenInHttpContext();

            if(idUser == 0) return Unauthorized();

            return 
                await _userService.DeleteUser(idUser) == true
                ? NoContent() 
                : BadRequest("Aucune correspondance");
        }


        /// <summary>
        /// Compare le paramètre d'entrée avec le passwd stocker en base de données d'un utilisateur connecter.
        /// </summary>
        /// <param name="passToUpdate">Paramètre à comparer de type : 'String'</param>
        /// <response code="204">Le passwd entrée en paramètre correspond à celui en base de données.</response>
        /// <response code="400">Le passwd entrée en paramètre ne correspond pas à celui stocker en base de données.</response>
        /// <response code="401">L'utilisateur n'est pas autorisée.</response>
        [HttpPost(nameof(CheckPasswd))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CheckPasswd([FromBody] UserCheckActualPass passToUpdate)
        {

            int idUser = _httpContextService.GetIdUserTokenInHttpContext();

            if (idUser == 0) return Unauthorized();

            try
            {
                bool response = await _userService.CheckPasswd(idUser, passToUpdate.Passwd);
                return Ok(true);
            }
            catch (BusinessException ex)
            {
                return BadRequest(new{ ex.Message});
            }
            
        }


        [HttpPost]
        public async Task<IActionResult> CheckMail(string mail)
        {

            bool mailValid  = _userService.CheckMail(mail);


            return mailValid ? Ok(mailValid) : BadRequest(new { mail });

        }
    }
}
