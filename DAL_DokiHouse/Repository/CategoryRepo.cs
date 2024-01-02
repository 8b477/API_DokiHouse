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

            // Exécute la requête et récupère le nombre de lignes affectées
            int rowsAffected = await _connection.ExecuteAsync(sql, category);

            return rowsAffected > 0;
        }


        public async Task<bool> Create(CategoryDTO model)
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

            // Exécute la requête et récupère le nombre de lignes affectées
            int rowAffected = await _connection.ExecuteAsync(sql, model);

            return rowAffected > 0;
        }


    }
}
