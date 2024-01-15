using DAL_DokiHouse.DTO.Post;
using DAL_DokiHouse.Interfaces;
using DAL_DokiHouse.Repository.Generic;

using Dapper;
using Entities_DokiHouse.Entities;

using System.Data;
using System.Data.Common;

namespace DAL_DokiHouse.Repository
{
    public class PostRepo : BaseRepo<Post, int, string>, IPostRepo
    {

        #region Injection
        public PostRepo(IDbConnection connection) : base(connection) {}

        #endregion


        public async Task<bool> Create(Post post)
        {
            string sql = @"
            INSERT INTO [Post]
            (Title, Description, Content, IdUser, CreateAt, ModifiedAt)
            VALUES (@Title, @Description, @Content, @IdUser, @CreateAt, @ModifiedAt)";

            DynamicParameters parameters = new();
            parameters.Add("@Title", post.Title);
            parameters.Add("@Description", post.Description);
            parameters.Add("@Content", post.Content);
            parameters.Add("@IdUser", post.IdUser);
            parameters.Add("@CreateAt", post.CreateAt);
            parameters.Add("@ModifiedAt", post.ModifiedAt);

            int rowAffected = await _connection.ExecuteAsync(sql, parameters);

            return rowAffected > 0;
        }


        public async Task<IEnumerable<Post>?> GetPosts(int idUser)
        {
            string sql = @"SELECT * FROM [Post]";

            IEnumerable<Post>? postCollection = await _connection.QueryAsync<Post>(sql, new { idUserParam = idUser });

            return postCollection;
        }


        public async Task<IEnumerable<Post>?> GetOwnPosts(int idUser)
        {
            string sql = @"SELECT * FROM [Post] WHERE IdUser = @idUserParam";

            IEnumerable<Post>? postCollection = await _connection.QueryAsync<Post>(sql, new { idUserParam = idUser});

            return postCollection;
        }


        public async Task<bool> Update(Post post)
        {
            string sql = @"
            UPDATE [Post]
            SET Description = @Description, @Content = Content 
            WHERE IdUser = @id";

            DynamicParameters parameters = new();
            parameters.Add("@Description", post.Description);
            parameters.Add("@Content", post.Content);

            int rowAffected = await _connection.ExecuteAsync(sql, parameters);

            return rowAffected < 0;
        }


        public async Task<PostAndCommentDTO>? GetPostsAndComments(int postId)
        {
            string sql = @"
            SELECT 
                p.Id, p.Title, p.Description, p.Content, p.CreateAt, p.ModifiedAt, p.IdUser,
                com.Id, com.IdUser, com.IdPost, com.Content, com.CreatedAt, com.ModifiedAt,
            FROM [dbo].[Post] p
            JOIN [dbo].[Comments] com ON com.IdPost = p.Id
            WHERE p.Id = @postId";

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
                    return existingPost;
                },
                new { UserId = postId },
                splitOn: "Id,Id");

            return postDictionary.Values.FirstOrDefault() ?? new PostAndCommentDTO();
        }

    }
}
