using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;
using Dapper;


using System.Data.Common;

namespace DAL_DokiHouse.Repository
{
    public class StyleRepo : IStyleRepo
    {

        #region Injection

        private readonly DbConnection _connection;

        public StyleRepo(DbConnection connection) => _connection = connection;

        #endregion



        public async Task<bool> Create(StyleDTO style)
        {
            string sql = @"
        INSERT INTO [Style] 
            (Bunjin,Bankan,Korabuki,Ishituki,Perso, IdBonsai, CreateAt, ModifiedAt)
        VALUES 
            (@Bunjin,@Bankan,@Korabuki,@Ishituki,@Perso, @IdBonsai, @CreateAt, @ModifiedAt)";

            DynamicParameters parameters = new();
            parameters.Add("@Bunjin",style.Bunjin);
            parameters.Add("@Bankan", style.Bankan);
            parameters.Add("@Korabuki", style.Korabuki);
            parameters.Add("@Ishituki", style.Ishituki);
            parameters.Add("@Perso", style.Perso);
            parameters.Add("@IdBonsai", style.IdBonsai);
            parameters.Add("@CreateAt", style.CreatedAt);
            parameters.Add("@ModifiedAt", style.ModifiedAt);

            int rowsAffected = await _connection.ExecuteAsync(sql, parameters);

            return rowsAffected > 0;
        }


        public async Task<bool> Update(StyleDTO style)
        {
            string sql = @"
        UPDATE [Style]
        SET 
            Bunjin = @Bunjin,
            Bankan = @Bankan,
            Korabuki = @Korabuki,
            Ishituki = @Ishituki,
            Perso = @Perso
        WHERE IdBonsai = @IdBonsai";

            int rowsAffected = await _connection.ExecuteAsync(sql, style);

            return rowsAffected > 0;
        }

  
        public async Task<bool> NotValide(int idBonsai)
        {
            string sql = @"
        SELECT TOP 1 1
        FROM [Style] 
        WHERE IdBonsai = @IdBonsai";

            int? result = await _connection.QueryFirstOrDefaultAsync<int?>(sql, new { IdBonsai = idBonsai });

            return result.HasValue; // Retourne true si une valeur est trouvée, false sinon
        }


    }
}
