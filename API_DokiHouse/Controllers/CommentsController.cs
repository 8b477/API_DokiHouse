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

            int id = _getInfosHTTPContext.GetLoggedInUserId();

            commentBLL.IdUser = id;
            commentBLL.IdPost = idPost;

            if (await _commentBllService.CreateComment(commentBLL)) return Ok();

            return BadRequest("L'insertion d'un nouveau post à échoué");
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<CommentsDTO>? result = await _commentBllService.GetComments();

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


        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            IEnumerable<CommentsDTO>? result = await _commentBllService.GetCommentsByName(name);

            return result is not null
                ? Ok(result)
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

    }
}
