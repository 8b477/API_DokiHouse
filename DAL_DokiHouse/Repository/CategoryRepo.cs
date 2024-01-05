using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;
using Dapper;

using System.Data.Common;

namespace DAL_DokiHouse.Repository
{
    public class CategoryRepo : ICategoryRepo
    {
        #region Injection
        private readonly DbConnection _connection;

        public CategoryRepo(DbConnection connection) => _connection = connection;
        #endregion



        public async Task<bool> Update(CategoryDTO category)
        {
            string sql = @"
        UPDATE [Category]
        SET 
            Shohin = @Shohin,
            Mame = @Mame,
            Chokkan = @Chokkan,
            Moyogi = @Moyogi,
            Shakan = @Shakan,
            Kengai = @Kengai,
            HanKengai = @HanKengai,
            Ikadabuki = @Ikadabuki,
            Neagari = @Neagari,
            Literati = @Literati,
            YoseUe = @YoseUe,
            Ishitsuki = @Ishitsuki,
            Kabudachi = @Kabudachi,
            Kokufu = @Kokufu,
            Yamadori = @Yamadori,
            Perso = @Perso
        WHERE IdBonsai = @IdBonsai";

            var parameters = new DynamicParameters();
            parameters.Add("@Shohin", category.Shohin);
            parameters.Add("@Mame", category.Mame);
            parameters.Add("@Chokkan", category.Chokkan);
            parameters.Add("@Moyogi", category.Moyogi);
            parameters.Add("@Shakan", category.Shakan);
            parameters.Add("@Kengai", category.Kengai);
            parameters.Add("@HanKengai", category.HanKengai);
            parameters.Add("@Ikadabuki", category.Ikadabuki);
            parameters.Add("@Neagari", category.Neagari);
            parameters.Add("@Literati", category.Literati);
            parameters.Add("@YoseUe", category.YoseUe);
            parameters.Add("@Ishitsuki", category.Ishitsuki);
            parameters.Add("@Kabudachi", category.Kabudachi);
            parameters.Add("@Kokufu", category.Kokufu);
            parameters.Add("@Yamadori", category.Yamadori);
            parameters.Add("@Perso", category.Perso);
            parameters.Add("@IdBonsai", category.IdBonsai);


            // Exécute la requête et récupère le nombre de lignes affectées
            int rowsAffected = await _connection.ExecuteAsync(sql, parameters);

            return rowsAffected > 0;
        }


        public async Task<bool> Create(CategoryDTO category)
        {
            string sql = @"
        INSERT INTO [Category] (
            Shohin, Mame, Chokkan, Moyogi, Shakan,
            Kengai, HanKengai, Ikadabuki, Neagari, Literati,
            YoseUe, Ishitsuki, Kabudachi, Kokufu, Yamadori,
            Perso, IdBonsai
        ) VALUES (
            @Shohin, @Mame, @Chokkan, @Moyogi, @Shakan,
            @Kengai, @HanKengai, @Ikadabuki, @Neagari, @Literati,
            @YoseUe, @Ishitsuki, @Kabudachi, @Kokufu, @Yamadori,
            @Perso, @IdBonsai
        )";

            var parameters = new DynamicParameters();
            parameters.Add("@Shohin", category.Shohin);
            parameters.Add("@Mame", category.Mame);
            parameters.Add("@Chokkan", category.Chokkan);
            parameters.Add("@Moyogi", category.Moyogi);
            parameters.Add("@Shakan", category.Shakan);
            parameters.Add("@Kengai", category.Kengai);
            parameters.Add("@HanKengai", category.HanKengai);
            parameters.Add("@Ikadabuki", category.Ikadabuki);
            parameters.Add("@Neagari", category.Neagari);
            parameters.Add("@Literati", category.Literati);
            parameters.Add("@YoseUe", category.YoseUe);
            parameters.Add("@Ishitsuki", category.Ishitsuki);
            parameters.Add("@Kabudachi", category.Kabudachi);
            parameters.Add("@Kokufu", category.Kokufu);
            parameters.Add("@Yamadori", category.Yamadori);
            parameters.Add("@Perso", category.Perso);
            parameters.Add("@IdBonsai", category.IdBonsai);

            int rowAffected = await _connection.ExecuteAsync(sql, parameters);

            return rowAffected > 0;
        }


        public async Task<bool> NotValide(int idBonsai)
        {
            string sql = @"
        SELECT TOP 1 1
        FROM [Category] 
        WHERE IdBonsai = @IdBonsai";

            int? result = await _connection.QueryFirstOrDefaultAsync<int?>(sql, new { IdBonsai = idBonsai });

            return result.HasValue; // Retourne true si une valeur est trouvée, false sinon
        }
    }
}
