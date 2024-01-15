using DAL_DokiHouse.Interfaces;
using DAL_DokiHouse.Repository.Generic;
using Dapper;
using Entities_DokiHouse.Entities;
using System.Data;


namespace DAL_DokiHouse.Repository
{
    public class StyleRepo : BaseRepo<Style, int, string>, IStyleRepo
    {

        #region Injection
        public StyleRepo(IDbConnection connection) : base(connection) { }

        #endregion



        public async Task<bool> Create(int idBonsai, Style style)
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
            parameters.Add("@Perso", style.StylePerso);
            parameters.Add("@CreateAt", style.CreatedAt);
            parameters.Add("@ModifiedAt", style.ModifiedAt);
            parameters.Add("@IdBonsai", idBonsai);

            int rowsAffected = await _connection.ExecuteAsync(sql, parameters);

            return rowsAffected > 0;
        }


        public async Task<bool> Update(int idStyle, Style style)
        {
            string sql = @"
            UPDATE [Style]
            SET 
            Bunjin = @Bunjin,
            Bankan = @Bankan,
            Korabuki = @Korabuki,
            Ishituki = @Ishituki,
            ModfiedAt = @ModifiedAt
            Perso = @Perso
            WHERE Id = @IdStyle";

            DynamicParameters parameters = new();
            parameters.Add("@Bunjin", style.Bunjin);
            parameters.Add("@Bankan", style.Bankan);
            parameters.Add("@Korabuki", style.Korabuki);
            parameters.Add("@Ishituki", style.Ishituki);
            parameters.Add("@Perso", style.StylePerso);
            parameters.Add("@ModifiedAt", style.ModifiedAt);
            parameters.Add("@IdStyle", idStyle);


            int rowsAffected = await _connection.ExecuteAsync(sql, style);

            return rowsAffected > 0;
        }

  
        public async Task<bool> IsAlreadyExists(int idBonsai)
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
