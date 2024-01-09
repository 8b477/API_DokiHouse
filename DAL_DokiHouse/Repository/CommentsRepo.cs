
using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;
using Dapper;
using Entities_DokiHouse.Entities;
using System.Data;


namespace DAL_DokiHouse.Repository
{
    public class CommentsRepo : BaseRepo<Comments, CommentsDTO, int, string>, ICommentsRepo
    {
        #region Injection
        public CommentsRepo(IDbConnection connection) : base(connection){}
        #endregion


        public async Task<bool> Create(CommentsDTO comments)
        {
            string sql = @"
            INSERT INTO [Comments]
            (Content, CreateAt, IdUser)
            VALUES (@Content, @CreateAt, @IdUser)";

            int rowsAffected = await _connection.ExecuteAsync(sql, comments);

            return rowsAffected > 0;
        }


        public async Task<bool> Update(CommentsDTO comments)
        {
            string sql = @"
            UPDATE [Comments]
            SET Content = @Content
            WHERE IdBonsai = @IdBonsai";

            DynamicParameters parameters = new();
            parameters.Add("@Content", comments.Content);


            int rowsAffected = await _connection.ExecuteAsync(sql, parameters);

            return rowsAffected > 0;
        }
    }
}
