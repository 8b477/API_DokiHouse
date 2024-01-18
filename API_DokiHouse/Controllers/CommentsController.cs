using API_DokiHouse.Models;
using API_DokiHouse.Tools;
using BLL_DokiHouse.Interfaces;
using Entities_DokiHouse.Entities;
using Microsoft.AspNetCore.Mvc;
using Tools_DokiHouse.Filters.JwtIdentifiantFilter;

namespace API_DokiHouse.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(JwtUserIdentifiantFilter))]
    [ApiController]
    public class CommentsController : ControllerBase
    {

        #region Injection
        private readonly ICommentsBLLService _commentBllService;
        private readonly GetInfosHTTPContext _getInfosHTTPContext;
        public CommentsController(ICommentsBLLService commentBllService, GetInfosHTTPContext getInfosHTTPContext)
            => (_commentBllService, _getInfosHTTPContext) = (commentBllService, getInfosHTTPContext);
        #endregion



        /// <summary>
        /// Crée un nouveau commentaire pour un post spécifié.
        /// </summary>
        /// <param name="comment">Modèle du commentaire à créer.</param>
        /// <param name="idPost">Identifiant du post pour lequel le commentaire est créé.</param>
        /// <returns>Retourne une action HTTP indiquant le succès ou l'échec de la création du commentaire.</returns>
        [HttpPost("{idPost:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Create([FromBody] CommentModel comment, int idPost)
        {
            int idToken = _getInfosHTTPContext.GetIdUserTokenInHttpContext();

            if (idToken == 0) return Unauthorized();

            if (await _commentBllService.CreateComment(comment, idPost, idToken))
                return CreatedAtAction(nameof(Create), comment);

            return BadRequest("L'insertion d'un nouveau commentaire à échoué");
        }


        /// <summary>
        /// Récupère tous les commentaires.
        /// </summary>
        /// <returns>Retourne une action HTTP avec la liste des commentaires s'il y en a, sinon NoContent.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Comments>? result = await _commentBllService.GetComments();

            return result is not null
            ? Ok(result)
            : NoContent();
        }


        /// <summary>
        /// Récupère les commentaires appartenant à l'utilisateur authentifié.
        /// </summary>
        /// <returns>Retourne une action HTTP avec les commentaires de l'utilisateur s'il y en a, sinon NoContent.</returns>
        [HttpGet(nameof(Own))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Own()
        {
            int idToken = _getInfosHTTPContext.GetIdUserTokenInHttpContext();

            if (idToken == 0) return Unauthorized();

            IEnumerable<Comments>? result = await _commentBllService.GetOwnComments(idToken);

            return result is not null
            ? Ok(result)
            : NoContent();
        }


        /// <summary>
        /// Récupère un commentaire par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant du commentaire à récupérer.</param>
        /// <returns>Retourne une action HTTP avec le commentaire s'il existe, sinon NoContent.</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetById(int id)
        {
            Comments? comment = await _commentBllService.GetCommentById(id);

            return comment is not null
                ? Ok(comment)
            : NoContent();
        }


        /// <summary>
        /// Met à jour les informations d'un commentaire.
        /// </summary>
        /// <param name="comment">Modèle contenant les nouvelles informations du commentaire.</param>
        /// <param name="id">Identifiant du commentaire à mettre à jour.</param>
        /// <returns>Retourne une action HTTP indiquant le succès ou l'échec de la mise à jour du commentaire.</returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] CommentModel comment, int id)
        {
            if (await _commentBllService.UpdateComment(comment, id))
                return Ok();

            return BadRequest();
        }


        /// <summary>
        /// Supprime un commentaire par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant du commentaire à supprimer.</param>
        /// <returns>Retourne une action HTTP indiquant le succès ou l'échec de la suppression.</returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(int id)
        {
            return
                await _commentBllService.DeleteComment(id)
                ? NoContent()
                : BadRequest();
        }


    }
}
