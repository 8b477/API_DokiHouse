using DAL_DokiHouse.Interfaces;
using DAL_DokiHouse.Repository.Generic;
using Dapper;
using Entities_DokiHouse.Entities;
using System.Data;


namespace DAL_DokiHouse.Repository
{
    public class PostRepo : BaseRepo<Post, int, string>, IPostRepo
    {

        #region Injection
        public PostRepo(IDbConnection connection) : base(connection) { }

        #endregion


        public async Task<bool> Create(int idUser, Post post)
        {
            string sql = @"
            INSERT INTO [Post]
            (Title, Description, Content, IdUser, CreateAt, ModifiedAt)
            VALUES (@Title, @Description, @Content, @IdUser, @CreateAt, @ModifiedAt)";

            DynamicParameters parameters = new();
            parameters.Add("@Title", post.Title);
            parameters.Add("@Description", post.Description);
            parameters.Add("@Content", post.Content);
            parameters.Add("@CreateAt", post.CreateAt);
            parameters.Add("@ModifiedAt", post.ModifiedAt);
            parameters.Add("@IdUser", idUser);

            int rowAffected = await _connection.ExecuteAsync(sql, parameters);

            return rowAffected > 0;
        }


        public async Task<bool> Update(int idPost, Post post)
        {
            string sql = @"
            UPDATE [Post]
            SET
            Title = @Title,
            Description = @Description,
            Content = @Content,
            ModifiedAt = @ModifiedAt
            WHERE IdUser = @id AND Id = @idPost";

            DynamicParameters parameters = new();
            parameters.Add("@Title", post.Title);
            parameters.Add("@Description", post.Description);
            parameters.Add("@Content", post.Content);
            parameters.Add("@ModifiedAt", post.ModifiedAt);
            parameters.Add("@id", post.IdUser);
            parameters.Add("@idPost", idPost);

            int rowAffected = await _connection.ExecuteAsync(sql, parameters);

            return rowAffected > 0;
        }


        public async Task<IEnumerable<Post>?> OwnPost(int idUser)
        {
            string sql = @"
            SELECT 
            p.Id, p.Title, p.Description, p.Content, p.CreateAt, p.ModifiedAt, p.IdUser
            FROM [dbo].[Post] p
            WHERE p.IdUser = @IdUser";

            IEnumerable<Post>? request = await _connection.QueryAsync<Post>(sql, new { IdUser = idUser });

            return request;
        }


    }
}
