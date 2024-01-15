using DAL_DokiHouse.Interfaces;
using DAL_DokiHouse.Repository.Generic;
using Dapper;
using Entities_DokiHouse.Entities;
using System.Data;


namespace DAL_DokiHouse.Repository
{
    public class NoteRepo : BaseRepo<Note, int, string>, INoteRepo
    {

        #region Injection
        public NoteRepo(IDbConnection connection) : base(connection) { }
        #endregion


        public async Task<bool> Create(Note note)
        {
            string sql = @"
            INSERT INTO [Note] 
            (Title, Description, IdBonsai, CreateAt, ModifiedAt)
            VALUES (@Title,@Description,@IdBonsai, @CreateAt, @ModifiedAt)";

            DynamicParameters parameters = new();
            parameters.Add("@Title", note.Title);
            parameters.Add("@Description", note.Description);
            parameters.Add("@IdBonsai", note.Id);
            parameters.Add("@CreateAt",note.CreatedAt);
            parameters.Add("@ModifiedAt",note.ModifiedAt);

            int rowsAffected = await _connection.ExecuteAsync(sql, parameters);

            return rowsAffected > 0;
        }

        public async Task<bool> Update(Note note)
        {
            string sql = @"
            UPDATE [Note]
            SET 
            Title = @Title,
            Description = @Description
            WHERE IdBonsai = @IdBonsai";

            DynamicParameters parameters = new();
            parameters.Add("@Title", note.Title);
            parameters.Add("@Description", note.Description);
            parameters.Add("@IdBonsai", note.Id);

            int rowsAffected = await _connection.ExecuteAsync(sql, parameters);

            return rowsAffected > 0;
        }

        public async Task<bool> NotValide(int idBonsai)
        {
            string sql = @"
        SELECT TOP 1 1
        FROM [Note] 
        WHERE IdBonsai = @IdBonsai";

            int? result = await _connection.QueryFirstOrDefaultAsync<int?>(sql, new { IdBonsai = idBonsai });

            return result.HasValue; // Retourne true si une valeur est trouvée, false sinon
        }

    }
}
