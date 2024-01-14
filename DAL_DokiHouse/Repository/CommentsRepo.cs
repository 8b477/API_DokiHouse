using DAL_DokiHouse.Interfaces;
using Dapper;
using Entities_DokiHouse.Entities;
using System.Data.Common;


namespace DAL_DokiHouse.Repository
{
    public class CommentsRepo : ICommentsRepo
    {

        #region Injection
        private readonly DbConnection _connection;

        public CommentsRepo(DbConnection connection) => _connection = connection;
        #endregion


        public async Task<bool> Create(Comments comments)
        {
            string sql = @"
            INSERT INTO [Comments]
            (Content, IdUser, IdPost, CreatedAt, ModifiedAt)
            VALUES (@Content, @IdUser, @IdPost, @CreatedAt, @ModifiedAt)";

            DynamicParameters parameters = new();
            parameters.Add("@Content", comments.Content);
            parameters.Add("@IdUser", comments.IdUser);
            parameters.Add("@IdPost", comments.IdPost);
            parameters.Add("@CreatedAt", comments.CreatedAt);
            parameters.Add("@ModifiedAt", comments.ModifiedAt);

            int rowsAffected = await _connection.ExecuteAsync(sql, parameters);

            return rowsAffected > 0;
        }


        public async Task<bool> Update(int Id, Comments comments)
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
