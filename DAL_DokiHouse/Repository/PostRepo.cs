

using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;

using Dapper;

using Entities_DokiHouse.Entities;

using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Runtime.InteropServices;

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
        VALUES (Description, Content, CreateAt, IdUser)
        VALUES ( @Description, @Content, @CreateAt, @IdUser )";


            DynamicParameters parameters = new();
            parameters.Add("@Description", post.Description);
            parameters.Add("@Content", post.Content);
            parameters.Add("@CreateAt", post.CreateAt);
            parameters.Add("@IdUser", post.IdUser);


            int rowAffected = await _connection.ExecuteAsync(sql, parameters);

            return rowAffected > 0;
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
