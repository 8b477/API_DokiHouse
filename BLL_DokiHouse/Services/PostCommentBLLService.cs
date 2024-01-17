using BLL_DokiHouse.Interfaces;
using DAL_DokiHouse.DTO.Post;
using DAL_DokiHouse.Interfaces;


namespace BLL_DokiHouse.Services
{
    public class PostCommentBLLService : IPostCommentBLLService
    {

        #region INJECTION
        private readonly IPostCommentRepo _postCommentRepo;
        public PostCommentBLLService(IPostCommentRepo postCommentRepo) => _postCommentRepo = postCommentRepo;
        #endregion



        public async Task<IEnumerable<PostAndCommentDTO>?> GetPostsAndComments(int startIndex, int pageSize)
        {
            return await _postCommentRepo.GetPostsAndComments(startIndex, pageSize);
        }


        public async Task<IEnumerable<PostAndCommentDTO>?> GetPostsAndComments(int idUser)
        {
            return await _postCommentRepo.GetPostsAndComments(idUser);
        }


    }
}
