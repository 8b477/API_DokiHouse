using BLL_DokiHouse.Interfaces;
using DAL_DokiHouse.DTO.Post;
using Microsoft.AspNetCore.Mvc;


namespace API_DokiHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostCommentController : ControllerBase
    {

        #region INJECTION
        private readonly IPostCommentBLLService _postCommentBLLService;
        public PostCommentController(IPostCommentBLLService postCommentBLLService) => _postCommentBLLService = postCommentBLLService;
        #endregion



        /// <summary>
        /// Récupère une liste de posts avec leurs commentaires associés en fonction du startIndex et du pageSize.
        /// </summary>
        /// <param name="startIndex">Index de départ pour la pagination (par défaut : 1).</param>
        /// <param name="pageSize">Nombre d'éléments par page (par défaut : 12).</param>
        /// <returns>
        /// Une action HTTP avec le statut Ok et la liste des posts avec commentaires si la récupération réussit,
        /// sinon BadRequest.
        /// </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PostAndCommentDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Get([FromQuery] int startIndex = 1, [FromQuery] int pageSize = 12)
        {
            if (startIndex < 0) return BadRequest("Le startIndex ne peut pas être inférieur à zéro");
            if (pageSize < 0) return BadRequest("Le pageSize ne peut pas être inférieur à zéro");

            startIndex--;

            IEnumerable<PostAndCommentDTO>? postComment = await _postCommentBLLService.GetPostsAndComments(startIndex, pageSize);

            return
                postComment is not null
                ? Ok(postComment)
                : BadRequest();
        }


        /// <summary>
        /// Récupère une liste de posts avec leurs commentaires associés en fonction de l'ID de l'utilisateur.
        /// </summary>
        /// <param name="idUser">ID de l'utilisateur pour lequel récupérer les posts avec commentaires.</param>
        /// <returns>
        /// Une action HTTP avec le statut Ok et la liste des posts avec commentaires si la récupération réussit,
        /// sinon BadRequest.
        /// </returns>
        [HttpGet("{idUser:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PostAndCommentDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Get(int idUser)
        {
            IEnumerable<PostAndCommentDTO>? postComment = await _postCommentBLLService.GetPostsAndComments(idUser);

            return
                postComment is not null
                ? Ok(postComment)
                : BadRequest();
        }

    }

}
