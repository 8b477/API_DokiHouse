﻿using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;
using Dapper;

using System.Data;

namespace DAL_DokiHouse.Repository
{
    public class NoteRepo : INoteRepo
    {

        #region Injection
        private readonly IDbConnection _connection;

        public NoteRepo(IDbConnection connection) => _connection = connection;
        #endregion


        public async Task<bool> Create(NoteDTO model)
        {
            string sql = @"
        INSERT INTO [Note] 
            (Title, Description, IdBonsai, CreateAt, ModifiedAt)
        VALUES 
            (@Title,@Description,@IdBonsai, @CreateAt, @ModifiedAt)";

            DynamicParameters parameters = new();
            parameters.Add("@Title", model.Title);
            parameters.Add("@Description", model.Description);
            parameters.Add("@IdBonsai", model.IdBonsai);
            parameters.Add("@CreateAt", model.CreateAt);
            parameters.Add("@ModifiedAt", model.ModifiedAt);

            int rowsAffected = await _connection.ExecuteAsync(sql, parameters);

            return rowsAffected > 0;
        }

        public async Task<bool> Update(NoteDTO model)
        {
            string sql = @"
        UPDATE [Note]
        SET 
            Title = @Title,
            Description = @Description
        WHERE IdBonsai = @IdBonsai";

            DynamicParameters parameters = new();
            parameters.Add("@Title", model.Title);
            parameters.Add("@Description", model.Description);
            parameters.Add("@IdBonsai", model.IdBonsai);

            int rowsAffected = await _connection.ExecuteAsync(sql, parameters);

            return rowsAffected > 0;
        }

        public async Task<bool> Delete(int id)
        {
            string query = $"DELETE FROM [Note] WHERE ID = @Id";

            int rowsAffected = await _connection.ExecuteAsync(query, new { Id = id });

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
