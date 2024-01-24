using DAL_DokiHouse.Interfaces;
using DAL_DokiHouse.Repository.Generic;
using Dapper;
using Entities_DokiHouse.Entities;
using System.Data;



namespace DAL_DokiHouse.Repository
{
    public class CommentsRepo : BaseRepo<Comments, int, string>, ICommentsRepo
    {

        #region Injection
        public CommentsRepo(IDbConnection connection) : base(connection) { }

        #endregion


        public async Task<bool> Create(int idPost, Comments comments)
        {
            string sql = @"
            INSERT INTO [Comments]
            (Content, IdUser, IdPost, CreateAt, ModifiedAt)
            VALUES (@Content, @IdUser, @IdPost, @CreateAt, @ModifiedAt)";

            DynamicParameters parameters = new();
            parameters.Add("@Content", comments.Content);
            parameters.Add("@IdUser", comments.IdUser);
            parameters.Add("@IdPost", idPost);
            parameters.Add("@CreateAt", comments.CreateAt);
            parameters.Add("@ModifiedAt", comments.ModifiedAt);

            int rowsAffected = await _connection.ExecuteAsync(sql, parameters);

            return rowsAffected > 0;
        }


        public async Task<bool> Update(int Id, Comments comments)
        {
            string sql = @"
            UPDATE [Comments]
            SET 
            Content = @Content,
            ModifiedAt = @ModifiedAt
            WHERE Id = @Id";

            DynamicParameters parameters = new();
            parameters.Add("@Content", comments.Content);
            parameters.Add("@ModifiedAt", comments.ModifiedAt);
            parameters.Add("@Id", Id);

            int rowsAffected = await _connection.ExecuteAsync(sql, parameters);

            return rowsAffected > 0;
        }


        public async Task<IEnumerable<Comments>?> GetOwnComments(int id)
        {
            string sql = @"SELECT * FROM [Comments] WHERE IdUser = @idParam";

            IEnumerable<Comments> CommentsCollection = await _connection.QueryAsync<Comments>(sql, new { idParam = id });

            return CommentsCollection;
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
