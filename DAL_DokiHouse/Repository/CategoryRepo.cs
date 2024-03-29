﻿using DAL_DokiHouse.Interfaces;
using DAL_DokiHouse.Repository.Generic;
using Dapper;
using Entities_DokiHouse.Entities;
using System.Data;


namespace DAL_DokiHouse.Repository
{
    public class CategoryRepo : BaseRepo<Category, int, string>, ICategoryRepo
    {
        #region Injection
        public CategoryRepo(IDbConnection connection) : base(connection) { }

        #endregion


        public async Task<bool> Update(int idCategory, Category category)
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
            Perso = @Perso,
            ModifiedAt = @ModifiedAt
            WHERE Id = @IdCate";

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
            parameters.Add("@Perso", category.CatePerso);
            parameters.Add("@IdCate", idCategory);
            parameters.Add("@ModifiedAt", category.ModifiedAt);

            int rowsAffected = await _connection.ExecuteAsync(sql, parameters);

            return rowsAffected > 0;
        }


        public async Task<bool> Create(Category category, int idBonsai)
        {
            string sql = @"
            INSERT INTO [Category] 
            (Shohin, Mame, Chokkan, Moyogi, Shakan, Kengai, HanKengai, Ikadabuki, Neagari, Literati,
            YoseUe, Ishitsuki, Kabudachi, Kokufu, Yamadori, Perso, IdBonsai, CreateAt, ModifiedAt)
            VALUES (@Shohin, @Mame, @Chokkan, @Moyogi, @Shakan,
            @Kengai, @HanKengai, @Ikadabuki, @Neagari, @Literati,
            @YoseUe, @Ishitsuki, @Kabudachi, @Kokufu, @Yamadori,
            @Perso, @IdBonsai, @CreateAt, @ModifiedAt)";

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
            parameters.Add("@Perso", category.CatePerso);
            parameters.Add("@CreateAt", category.CreateAt);
            parameters.Add("@ModifiedAt", category.ModifiedAt);
            parameters.Add("@IdBonsai", idBonsai);

            int rowAffected = await _connection.ExecuteAsync(sql, parameters);

            return rowAffected > 0;
        }


        public async Task<bool> IsAlreadyExists(int idBonsai)
        {
            string sql = @"
            SELECT TOP 1 1
            FROM [Category] 
            WHERE IdBonsai = @IdBonsai";

            int? result = await _connection.QueryFirstOrDefaultAsync<int?>(sql, new { IdBonsai = idBonsai });

            return result.HasValue; // Retourne true si une valeur est trouvée, sinon false
        }
    }
}
