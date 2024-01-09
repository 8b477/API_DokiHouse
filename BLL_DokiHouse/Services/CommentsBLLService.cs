using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Models;
using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;

using Mapper = BLL_DokiHouse.Tools.Mapper;


namespace BLL_DokiHouse.Services
{
    public class CommentsBLLService : ICommentsBLLService
    {

        #region Injection
        private readonly ICommentsRepo _repoComments;
        public CommentsBLLService(ICommentsRepo repoComments) => _repoComments = repoComments;
        #endregion

        public async Task<bool> CreateComment(CommentBLL comment)
        {

            CommentsDTO commentDTO = Mapper.CommentBLLToDAL(comment);

            return await _repoComments.Create(commentDTO);
        }


        public async Task<bool> DeleteComment(int id)
        {
            return await _repoComments.Delete(id);
        }

        public async Task<bool> UpdateComment(int id, CommentBLL comment)
        {
            CommentsDTO commentDTO = Mapper.CommentBLLToDAL(comment);

            return await _repoComments.Update(id, commentDTO);
        }


        public async Task<IEnumerable<CommentsDTO>> GetComments()
        {
            return await _repoComments.Get();
        }


        public async Task<CommentsDTO?> GetCommentById(int id)
        {
            return await _repoComments.GetBy(id);
        }


        public async Task<IEnumerable<CommentsDTO>?> GetCommentsByName(string name)
        {
            return await _repoComments.GetBy(name);
        }
    }
}
