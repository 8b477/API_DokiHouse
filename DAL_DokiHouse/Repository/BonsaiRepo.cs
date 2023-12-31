using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;
using Dapper;
using Entities_DokiHouse.Entities;

using System.Data;

namespace DAL_DokiHouse.Repository
{
    public class BonsaiRepo : BaseRepo<Bonsai, BonsaiDTO, BonsaiCreateDTO, BonsaiDisplayDTO, int, string>, IBonsaiRepo
    {

        #region Constructeur
        public BonsaiRepo(IDbConnection connection) : base(connection) {}
        #endregion


        public async Task<int> CreateBonsai(BonsaiCreateDTO model)
        {
            string sql = @"
            INSERT INTO [Bonsai] (Name, Description, IdUser)
            VALUES (@Name, @Description, @IdUser);
            SELECT CAST(SCOPE_IDENTITY() AS INT);";

            // Exécute la requête et récupère l'ID généré
            int idBonsai = await _connection.QuerySingleAsync<int>(sql, model);

            return idBonsai;
        }


        public async Task<bool> UpdateBonsai(BonsaiDTO bonsai)
        {
            string sql = "UPDATE [Bonsai] SET Name = @Name,Description = @Description WHERE Id = @id";

            DynamicParameters parameters = new();
            parameters.Add("@Name",bonsai.Name);
            parameters.Add("@Description",bonsai.Description);
            parameters.Add("@id", bonsai.Id);

            int result = await _connection.ExecuteAsync(sql, parameters);

            return result > 0;
        }



        public async Task<IEnumerable<BonsaiCateExp>?> GetAllBonsai()
        {
            string sql = @"
        SELECT b.Id AS IdBonsai, b.Name, b.Description, b.IdUser,
               c.Id AS IdCategory, c.Shohin, c.Mame, c.Chokkan, c.Moyogi, c.Shakan,
               c.Kengai, c.HanKengai, c.Ikadabuki, c.Neagari, c.Literati, c.YoseUe,
               c.Ishitsuki, c.Kabudachi, c.Kokufu, c.Yamadori, c.Perso,
               s.Id AS IdStyle, s.Chokkan, s.Moyogi, s.Shakan, s.Kengai, s.HanKengai,
               s.Ikadabuki, s.Neagari, s.Bunjin, s.YoseUe, s.Ishitsuki, s.Kabudachi,
               s.Bankan, s.Korabuki, s.Yamadori, s.Ishituki, s.Perso AS StylePerso,
               n.Id AS IdNote, n.Title, n.Description, n.CreateAt
        FROM [Bonsai] b
        LEFT JOIN [Category] c ON b.Id = c.IdBonsai
        LEFT JOIN [Style] s ON b.Id = s.IdBonsai
        LEFT JOIN [Note] n ON b.Id = n.IdBonsai";

            var bonsaiCategories = await _connection.QueryAsync<BonsaiCateExp, CategoryDTO, StyleDTO, NoteDTO, BonsaiCateExp>(
                sql,
                (bonsai, category, style, note) =>
                {
                    bonsai.Category = category;
                    bonsai.Style = style;
                    bonsai.Note = note;

                    return bonsai;
                },
                splitOn: "IdCategory,IdStyle,IdNote");

            return bonsaiCategories;
        }

    }

}
