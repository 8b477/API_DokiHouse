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


        [HttpPost("{idPost:int}")]
        public async Task<IActionResult> Create([FromBody] CommentModel comment, int idPost)
        {
            int idToken = _getInfosHTTPContext.GetIdUserTokenInHttpContext();

            if (idToken == 0) return Unauthorized();

            if (await _commentBllService.CreateComment(comment,idPost, idToken))
                return CreatedAtAction(nameof(Create),comment);

            return BadRequest("L'insertion d'un nouveau commentaire à échoué");
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Comments>? result = await _commentBllService.GetComments();

            return result is not null
            ? Ok(result)
            : NoContent();
        }



        [HttpGet(nameof(Own))]
        public async Task<IActionResult> Own()
        {
            int idToken = _getInfosHTTPContext.GetIdUserTokenInHttpContext();

            if (idToken == 0) return Unauthorized();

            IEnumerable<Comments>? result = await _commentBllService.GetOwnComments(idToken);

            return result is not null
            ? Ok(result)
            : NoContent();
        }



        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            Comments? comment = await _commentBllService.GetCommentById(id);

            return comment is not null
                ? Ok(comment)
            : NoContent();
        }



        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromBody] CommentModel comment, int id)
        {
            if (await _commentBllService.UpdateComment(comment, id))
                return Ok();

            return BadRequest();
        }



        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return
                await _commentBllService.DeleteComment(id)
                ? NoContent()
                : BadRequest();
        }

    }
}
