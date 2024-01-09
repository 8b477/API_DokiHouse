using API_DokiHouse.Models;
using API_DokiHouse.Services;
using API_DokiHouse.Tools;
using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Models;
using DAL_DokiHouse.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API_DokiHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        #region Injection
        private readonly IPostBLLService _postBLLService;
        private readonly GetInfosHTTPContext _getInfosHTTPContext;
        public PostController(IPostBLLService postBLLService, GetInfosHTTPContext getInfosHTTPContext)
            => (_postBLLService, _getInfosHTTPContext) = (postBLLService, getInfosHTTPContext);
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
            PostBLL postDTO = Mapper.PostModelToPostBLL(post);

            int id = _getInfosHTTPContext.GetLoggedInUserId();
            postDTO.IdUser = id;

            if (await _postBLLService.CreatePost(postDTO))
                return Ok();

            return BadRequest("L'insertion d'un nouveau post a échoué");
        }


        /// <summary>
        /// Récupère la liste complète des posts.
        /// </summary>
        /// <returns>Retourne la liste des posts.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PostDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetPosts()
        {
            IEnumerable<PostDTO>? result = await _postBLLService.GetPosts();

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetPostById(int id)
        {
            PostDTO? post = await _postBLLService.GetPostById(id);

            return post is not null
                ? Ok(post)
                : NoContent();
        }


        /// <summary>
        /// Récupère la liste des posts par nom.
        /// </summary>
        /// <param name="name">Le nom à utiliser pour la recherche des posts.</param>
        /// <returns>Retourne la liste des posts correspondant au nom.</returns>
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PostDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetPostsByName(string name)
        {
            IEnumerable<PostDTO>? result = await _postBLLService.GetPostsByName(name);

            return result is not null
                ? Ok(result)
                : NoContent();
        }


        /// <summary>
        /// Met à jour les informations d'un post.
        /// </summary>
        /// <param name="post">Les données mises à jour du post.</param>
        /// <returns>Retourne un code 200 OK si la mise à jour est réussie, sinon un code 400 Bad Request.</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePost([FromBody] PostModel post)
        {
            PostBLL postDTO = Mapper.PostModelToPostBLL(post);

            if (await _postBLLService.UpdatePost(postDTO))
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
        public async Task<IActionResult> DeletePost(int id)
        {
            return await _postBLLService.DeletePost(id)
                ? NoContent()
                : BadRequest();
        }

    }
}
