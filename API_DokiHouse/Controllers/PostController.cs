using API_DokiHouse.Models;
using API_DokiHouse.Tools;
using BLL_DokiHouse.Interfaces;
using Entities_DokiHouse.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

using Tools_DokiHouse.Filters.JwtIdentifiantFilter;


namespace API_DokiHouse.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(JwtUserIdentifiantFilter))]
    [ApiController]
    public class PostController : ControllerBase
    {
        #region Injection
        private readonly IPostBLLService _postBLLService;
        private readonly GetInfosHTTPContext _httpContextService;
        public PostController(IPostBLLService postBLLService, GetInfosHTTPContext httpContextService)
            => (_postBLLService, _httpContextService) = (postBLLService, httpContextService);
        #endregion


        /// <summary>
        /// Crée un nouveau post.
        /// </summary>
        /// <param name="post">Les données du post à créer.</param>
        /// <returns>Retourne un code 200 OK si la création est réussie, sinon un code 400 Bad Request.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePost([FromBody] PostModel post)
        {
            if (!ModelState.IsValid) return BadRequest();

            int idToken = _httpContextService.GetIdUserTokenInHttpContext();

            if (idToken == 0) return Unauthorized();


            if (await _postBLLService.CreatePost(idToken, post))
                return CreatedAtAction(nameof(CreatePost),post);

            return BadRequest("L'insertion d'un nouveau post a échoué");
        }


        /// <summary>
        /// Récupère la liste complète des posts et leurs commentaires.
        /// </summary>
        /// <returns>Retourne la liste des posts et des commentaires lié.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Post>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Post>? result = await _postBLLService.GetPosts();

            return result is not null
                ? Ok(result)
                : NoContent();
        }


        /// <summary>
        /// Récupère un post en utilisant son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du post à récupérer.</param>
        /// <returns>Retourne le post correspondant à l'identifiant.</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Post))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get(int id)
        {
            Post? post = await _postBLLService.GetPostById(id);

            return post is not null
                ? Ok(post)
                : NoContent();
        }


        /// <summary>
        /// Récupère les post de l'utilisateur préalablement log.
        /// </summary>
        /// <returns>Retourne les post lié à l'identifiant de l'utilisateur connecter ou retourne 'rien' si pas de correspondance.</returns>
        [HttpGet(nameof(Own))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Post))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Own()
        {
            int idToken = _httpContextService.GetIdUserTokenInHttpContext();

            if (idToken == 0) return Unauthorized();

            IEnumerable<Post>? post = await _postBLLService.OwnPost(idToken);

            return post is not null
                ? Ok(post)
                : NoContent();
        }


        /// <summary>
        /// Récupère la liste des posts par nom.
        /// </summary>
        /// <param name="name">Le nom à utiliser pour la recherche des posts.</param>
        /// <param name="stringIdentifiant">Le nom de la colonne en DB a comparé avec la recherche, par défaut ça valeur est : 'Name'.</param>
        /// <returns>Retourne la liste des posts correspondant au nom.</returns>
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Post>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get(string name, string stringIdentifiant = "Name")
        {
            IEnumerable<Post>? result = await _postBLLService.GetPostsByName(name, stringIdentifiant);

            return result is not null
                ? Ok(result)
                : NoContent();
        }


        /// <summary>
        /// Met à jour les informations d'un post.
        /// </summary>
        /// <param name="idPost">L'identifiant du POST de type INT.</param>
        /// <param name="post">Les données mises à jour du post.</param>
        /// <returns>Retourne un code 200 OK si la mise à jour est réussie, sinon un code 400 Bad Request.</returns>
        [HttpPut("{idPost:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int idPost, [FromBody] PostModel post)
        {
            int idToken = _httpContextService.GetIdUserTokenInHttpContext();

            if (idToken == 0) return Unauthorized();

            if (await _postBLLService.UpdatePost(idPost,idToken, post))
                return Ok();

            return BadRequest();
        }


        /// <summary>
        /// Supprime un post en utilisant son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du post à supprimer.</param>
        /// <returns>Retourne un code 204 No Content si la suppression est réussie, sinon un code 400 Bad Request.</returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            return await _postBLLService.DeletePost(id)
                ? NoContent()
                : BadRequest();
        }

    }
}
