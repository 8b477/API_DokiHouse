using API_DokiHouse.Models;
using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Tools;

using DAL_DokiHouse.Interfaces;
using Entities_DokiHouse.Entities;


namespace BLL_DokiHouse.Services
{
    public class CommentsBLLService : ICommentsBLLService
    {

        #region Injection
        private readonly ICommentsRepo _repoComments;
        public CommentsBLLService(ICommentsRepo repoComments) => _repoComments = repoComments;
        #endregion

        public async Task<bool> CreateComment(CommentModel comment, int idPost)
        {
            Comments commentDAL = Mapping.CommentCreateBLLToDAL(comment);

            return await _repoComments.Create(idPost, commentDAL);
        }


        public async Task<bool> DeleteComment(int id)
        {
            return await _repoComments.Delete(id);
        }


        public async Task<bool> UpdateComment(CommentModel comment, int idComment)
        {
            Comments commentDAL = Mapping.CommentUpdateBLLToDAL(comment);

            return await _repoComments.Update(idComment, commentDAL);
        }


        public async Task<IEnumerable<Comments>> GetComments()
        {
            return await _repoComments.Get();
        }


        public async Task<IEnumerable<Comments>?> GetOwnComments(int idUser)
        {
            return await _repoComments.GetOwnComments(idUser);
        }


        public async Task<Comments?> GetCommentById(int id)
        {
            return await _repoComments.GetBy(id);
        }


        public async Task<IEnumerable<Comments>?> GetCommentsByName(string name, string stringIdentifiant)
        {
            return await _repoComments.GetBy(name, stringIdentifiant);
        }
    }
}
