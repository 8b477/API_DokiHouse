using API_DokiHouse.Models;
using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Tools;
using DAL_DokiHouse.DTO.Post;
using DAL_DokiHouse.Interfaces;
using Entities_DokiHouse.Entities;


namespace BLL_DokiHouse.Services
{
    public class PostBLLService : IPostBLLService
    {

        #region Injection
        private readonly IPostRepo _postRepo;
        public PostBLLService(IPostRepo postRepo) => _postRepo = postRepo;
        #endregion


        public async Task<bool> CreatePost(int idUser, PostModel post)
        {
            Post postDAL = Mapping.PostCreateBLLToDAL(post);

            return await _postRepo.Create(idUser, postDAL);
        }


        public async Task<bool> UpdatePost(int idPost,int idToken, PostModel post)
        {
            Post postDAL = Mapping.PostUpdateBLLToDAL(post);

            postDAL.IdUser = idToken;

            return await _postRepo.Update(idPost, postDAL);
        }


        public async Task<IEnumerable<Post>?> GetPosts()
        {
            return await _postRepo.Get();
        }


        public async Task<Post?> GetPostById(int id)
        {
            return await _postRepo.GetBy(id);
        }


        public async Task<IEnumerable<Post>?> GetPostsByName(string name, string stringIdentifiant)
        {
            return await _postRepo.GetBy(name, stringIdentifiant);
        }


        public async Task<bool> DeletePost(int id)
        {
            return await _postRepo.Delete(id);
        }


        public Task<IEnumerable<Post>?> OwnPost(int idUser)
        {
            return _postRepo.OwnPost(idUser);
        }
    }
}
