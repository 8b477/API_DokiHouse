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



        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int startIndex = 1,[FromQuery] int pageSize = 12)
        {

            if (startIndex < 0) return BadRequest("Le startIndex ne peut pas être inférieur de zéro");
            if (pageSize < 0) return BadRequest("Le startIndex ne peut pas être inférieur de zéro");

            startIndex--;

            IEnumerable<PostAndCommentDTO>? postComment = await _postCommentBLLService.GetPostsAndComments(startIndex, pageSize);

            return
                postComment is not null
                ? Ok(postComment)
                : BadRequest();
        }


        [HttpGet("{idUser:int}")]
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
