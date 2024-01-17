using DAL_DokiHouse.DTO.Post;
using DAL_DokiHouse.Interfaces;
using Dapper;
using Entities_DokiHouse.Entities;
using System.Data;


namespace DAL_DokiHouse.Repository
{
    public class PostCommentRepo : IPostCommentRepo
    {

        #region INJECTION
        private readonly IDbConnection _connection;
        public PostCommentRepo(IDbConnection connection) => _connection = connection;
        #endregion



        public async Task<IEnumerable<PostAndCommentDTO>?> GetPostsAndComments(int startIndex, int pageSize)
        {
            string sql = @"
            SELECT 
            p.Id, p.Title, p.Description, p.Content, p.CreateAt, p.ModifiedAt, p.IdUser,
            com.Id, com.IdUser, com.IdPost, com.Content, com.CreatedAt, com.ModifiedAt
            FROM [dbo].[Post] p
            LEFT JOIN [dbo].[Comments] com ON com.IdPost = p.Id
            WHERE p.IdUser = @idUser
            ORDER BY u.Id
            OFFSET @StartIndex ROWS FETCH NEXT @PageSize ROWS ONLY";

            var postDictionary = new Dictionary<int, PostAndCommentDTO>();

            await _connection.QueryAsync<PostAndCommentDTO, Comments, PostAndCommentDTO>(
                sql,
                (post, comment) =>
                {
                    if (!postDictionary.TryGetValue(post.Id, out var existingPost))
                    {
                        existingPost = post;
                        existingPost.CommentsCollection = new List<Comments>();
                        postDictionary.Add(existingPost.Id, existingPost);
                    }

                    if (comment is not null && existingPost.CommentsCollection is not null)
                    {
                        // Ajoutez le commentaire à la collection du post
                        existingPost.CommentsCollection.Add(comment);
                    }

                    return existingPost;
                },
                new { StartIndex = startIndex, PageSize = pageSize },
                splitOn: "Id,Id");

            return postDictionary.Values;
        }


        public async Task<IEnumerable<PostAndCommentDTO>?> GetPostsAndComments(int idUser)
        {
            string sql = @"
            SELECT 
            p.Id, p.Title, p.Description, p.Content, p.CreateAt, p.ModifiedAt, p.IdUser,
            com.Id, com.IdUser, com.IdPost, com.Content, com.CreatedAt, com.ModifiedAt
            FROM [dbo].[Post] p
            LEFT JOIN [dbo].[Comments] com ON com.IdPost = p.Id
            WHERE p.IdUser = @idUser"
            ;

            var postDictionary = new Dictionary<int, PostAndCommentDTO>();

            await _connection.QueryAsync<PostAndCommentDTO, Comments, PostAndCommentDTO>(
                sql,
                (post, comment) =>
                {
                    if (!postDictionary.TryGetValue(post.Id, out var existingPost))
                    {
                        existingPost = post;
                        existingPost.CommentsCollection = new List<Comments>();
                        postDictionary.Add(existingPost.Id, existingPost);
                    }

                    if (comment is not null && existingPost.CommentsCollection is not null)
                    {
                        // Ajoutez le commentaire à la collection du post
                        existingPost.CommentsCollection.Add(comment);
                    }

                    return existingPost;
                },
                new { IdUser = idUser },
                splitOn: "Id,Id");

            return postDictionary.Values;
        }


    }
}
