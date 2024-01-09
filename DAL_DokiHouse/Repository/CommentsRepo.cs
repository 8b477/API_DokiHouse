﻿
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
            (Content, CreateAt, IdUser, IdPost)
            VALUES (@Content, @CreateAt, @IdUser, @IdPost)
            WHERE IdPost = @IdPost";

            DynamicParameters parameters = new();
            parameters.Add("@Content", comments.Content);
            parameters.Add("@CreateAt", comments.CreatedAt);
            parameters.Add("@IdUser", comments.IdUser);
            parameters.Add("@IdPost", comments.IdPost);

            int rowsAffected = await _connection.ExecuteAsync(sql, comments);

            return rowsAffected > 0;
        }


        public async Task<bool> Update(int Id, CommentsDTO comments)
        {
            string sql = @"
            UPDATE [Comments]
            SET Content = @Content
            WHERE Id = @Id";

            DynamicParameters parameters = new();
            parameters.Add("@Content", comments.Content);
            parameters.Add("@Id", Id);

            int rowsAffected = await _connection.ExecuteAsync(sql, parameters);

            return rowsAffected > 0;
        }


        public async Task<bool> NotValide(int idUser)
        {
            string sql = @"
        SELECT TOP 1 1
        FROM [Comment] 
        WHERE IdUser = @IdUser";

            int? result = await _connection.QueryFirstOrDefaultAsync<int?>(sql, new { IdUser = idUser });

            return result.HasValue; // Retourne true si une valeur est trouvée, false sinon
        }
    }
}
