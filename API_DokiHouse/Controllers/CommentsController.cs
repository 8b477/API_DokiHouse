using API_DokiHouse.Models;
using API_DokiHouse.Services;
using API_DokiHouse.Tools;
using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Models;
using DAL_DokiHouse.DTO;
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


        [HttpPost("{idPost}:int")]
        public async Task<IActionResult> Create([FromBody] CommentModel comment, int idPost)
        {
            CommentBLL commentBLL = Mapper.CommentModelToCommentBLL(comment);

            int id = _getInfosHTTPContext.GetIdUserTokenInHttpContext();

            commentBLL.IdUser = id;
            commentBLL.IdPost = idPost;

            if (await _commentBllService.CreateComment(commentBLL)) return Ok();

            return BadRequest("L'insertion d'un nouveau commentaire à échoué");
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<CommentsDTO>? result = await _commentBllService.GetComments();

            return result is not null
            ? Ok(result)
            : NoContent();
        }


        [HttpGet(nameof(GetOwnComments))]
        public async Task<IActionResult> GetOwnComments()
        {
            int idToken = _getInfosHTTPContext.GetIdUserTokenInHttpContext();

            if (idToken == 0) return Unauthorized();

            IEnumerable<CommentsDTO>? result = await _commentBllService.GetOwnComments(idToken);

            return result is not null
            ? Ok(result)
            : NoContent();
        }


        [HttpGet("{id}:int")]
        public async Task<IActionResult> GetById(int id)
        {
            CommentsDTO? comment = await _commentBllService.GetCommentById(id);

            return comment is not null
                ? Ok(comment)
            : NoContent();
        }



        [HttpPut("{id}:int")]
        public async Task<IActionResult> Update([FromBody] CommentModel comment, int id)
        {

            CommentBLL commentBLL = Mapper.CommentModelToCommentBLL(comment);

            if (await _commentBllService.UpdateComment(id,commentBLL))
                return Ok();

            return BadRequest();
        }


        [HttpDelete("{id}:int")]
        public async Task<IActionResult> Delete(int id)
        {
            return
                await _commentBllService.DeleteComment(id)
                ? NoContent()
                : BadRequest();
        }


        //[HttpGet("{name}")]
        //public async Task<IActionResult> GetByName(string name, string stringIdentifiant)
        //{
        //    IEnumerable<CommentsDTO>? result = await _commentBllService.GetCommentsByName(name,stringIdentifiant);

        //    return result is not null
        //        ? Ok(result)
        //        : NoContent();
        //}

    }
}
