

using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;

using Dapper;

using Entities_DokiHouse.Entities;

using System.Data;

namespace DAL_DokiHouse.Repository
{
    public class PostRepo : BaseRepo<Post, PostDTO, int, string>, IPostRepo
    {
        #region Injection
        public PostRepo(IDbConnection connection) : base(connection){}

        #endregion


        public async Task<bool> Create(PostDTO post)
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

        public async Task<IEnumerable<PostDTO>?> GetOwnPosts(int idUser)
        {
            string sql = @"SELECT * FROM [Post] WHERE IdUser = @idUserParam";

            IEnumerable<PostDTO>? postCollection = await _connection.QueryAsync<PostDTO>(sql, new { idUserParam = idUser});

            return postCollection;
        }

        public async Task<bool> Update(PostDTO post)
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
    }
}
