using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Models;
using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;
using Mapper = BLL_DokiHouse.Tools.Mapper;


namespace BLL_DokiHouse.Services
{
    public class PostBLLService : IPostBLLService
    {

        #region Injection
        private readonly IPostRepo _postRepo;
        public PostBLLService(IPostRepo postRepo) => _postRepo = postRepo;
        #endregion


        public async Task<bool> CreatePost(PostBLL post)
        {
            PostDTO postDto = Mapper.PostBLLToDAL(post);

            return await _postRepo.Create(postDto);
        }


        public async Task<bool> UpdatePost(PostBLL post)
        {
            PostDTO postDto = Mapper.PostBLLToDAL(post);

            return await _postRepo.Update(postDto);
        }


        public async Task<IEnumerable<PostDTO>?> GetPosts()
        {
            return await _postRepo.Get();
        }

        public async Task<IEnumerable<PostDTO>?> GetOwnPosts(int idUser)
        {
            return await _postRepo.GetOwnPosts(idUser);
        }


        public async Task<PostDTO?> GetPostById(int id)
        {
            return await _postRepo.GetBy(id);
        }


        public async Task<IEnumerable<PostDTO>?> GetPostsByName(string name, string stringIdentifiant)
        {
            return await _postRepo.GetBy(name, stringIdentifiant);
        }


        public async Task<bool> DeletePost(int id)
        {
            return await _postRepo.Delete(id);
        }
    }
}
