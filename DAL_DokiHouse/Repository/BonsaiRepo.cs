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



        public async Task<bool> UpdateBonsai(BonsaiDTO bonsai)
        {
            string sql = "UPDATE [Bonsai] SET Name = @Name, Description = @Description WHERE IdUser = @id";

            DynamicParameters parameters = new();
            parameters.Add("@Name", bonsai.Name);
            parameters.Add("@Description", bonsai.Description);
            parameters.Add("@id", bonsai.Id);

            int result = await _connection.ExecuteAsync(sql, parameters);

            return result > 0;
        }




        public async Task<IEnumerable<BonsaiAndChild>?> GetAllBonsai()
        {
            // SQL pour récupérer les bonsaïs avec leurs informations associées
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

            // Exécute la requête et mappe les résultats dans la liste BonsaiAndChild
            var bonsaiCategories = await _connection.QueryAsync<BonsaiAndChild, CategoryDTO, StyleDTO, NoteDTO, BonsaiAndChild>(
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




        public async Task<IEnumerable<BonsaiAndChild>> GetAllBonsai(int idUser)
        {
            // SQL pour récupérer les bonsaïs avec leurs informations associées filtrés par IdUser
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
        LEFT JOIN [Note] n ON b.Id = n.IdBonsai
        WHERE b.IdUser = @idUserParam";

            // Exécute la requête et mappe les résultats dans la liste BonsaiAndChild
            var bonsaiCategories = await _connection.QueryAsync<BonsaiAndChild, CategoryDTO, StyleDTO, NoteDTO, BonsaiAndChild>(
                sql,
                (bonsai, category, style, note) =>
                {
                    bonsai.Category = category;
                    bonsai.Style = style;
                    bonsai.Note = note;

                    return bonsai;
                },
                new { idUserParam = idUser }, // Paramètre à passer dans la requête
                splitOn: "IdCategory,IdStyle,IdNote");

            return bonsaiCategories;
        }




        public async Task<IEnumerable<UserEveryDTO>?> GetTest()
        {
            // SQL pour récupérer les bonsaïs avec leurs informations associées
            string sql = @"
    SELECT u.Id AS UserId, u.Name AS UserName, u.Email, u.Role, u.IdPictureProfil,
           b.Id AS BonsaiId, b.Name AS BonsaiName, b.Description, b.IdUser AS BonsaiUserId,
           c.Id AS CategoryId, c.Shohin, c.Mame, c.Chokkan, c.Moyogi, c.Shakan,
           c.Kengai, c.HanKengai, c.Ikadabuki, c.Neagari, c.Literati, c.YoseUe,
           c.Ishitsuki, c.Kabudachi, c.Kokufu, c.Yamadori, c.Perso,
           s.Id AS StyleId, s.Chokkan, s.Moyogi, s.Shakan, 
           s.Kengai, s.HanKengai, s.Ikadabuki ,
           s.Neagari, s.Bunjin, s.YoseUe,
           s.Ishitsuki, s.Kabudachi, s.Bankan,
           s.Korabuki, s.Yamadori, s.Ishituki,
           s.Perso AS StylePerso,
           n.Id AS NoteId, n.Title, n.Description, n.CreateAt
    FROM [Bonsai] b
    LEFT JOIN [Category] c ON b.Id = c.IdBonsai
    LEFT JOIN [Style] s ON b.Id = s.IdBonsai
    LEFT JOIN [Note] n ON b.Id = n.IdBonsai
    LEFT JOIN [User] u ON b.IdUser = u.Id";

            var userEveryDTOs = await _connection.QueryAsync<UserEveryDTO, BonsaiAndChild, UserEveryDTO>(
                sql,
                (user, bonsai) =>
                {
                    user.BonsaiCollection ??= new List<BonsaiAndChild>();
                    bonsai.Category = bonsai.Category ?? new CategoryDTO();
                    bonsai.Style = bonsai.Style ?? new StyleDTO(); 
                    bonsai.Note = bonsai.Note ?? new NoteDTO(); 

                    user.BonsaiCollection.Add(bonsai); 
                    return user;
                },
                splitOn: "Id,BonsaiId,CategoryId,StyleId,NoteId");

            return userEveryDTOs;
        }

        public class UserEveryDTO
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int? IdPictureProfil { get; set; }
            public List<BonsaiAndChild> BonsaiCollection { get; set; }
        }
    }

}
