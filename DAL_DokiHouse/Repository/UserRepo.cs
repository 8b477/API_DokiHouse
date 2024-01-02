using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Repository;
using Entities_DokiHouse.Entities;

using Dapper;
using System.Data;
namespace DAL_DokiHouse
{
    public class UserRepo : BaseRepo<User, UserDTO, UserCreateDTO, UserDisplayDTO, int, string>, IUserRepo
    {

        #region Constructor

        public UserRepo(IDbConnection connection) : base(connection) { }

        #endregion


        public async Task<User?> Logger(string email, string motDePasse)
        {
            string query = "SELECT Passwd FROM [User] WHERE Email = @EmailParam";

            string? hashedPassword = await _connection.QueryFirstOrDefaultAsync<string>(query, new { EmailParam = email });

            if (hashedPassword != null)
            {
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(motDePasse, hashedPassword);

                if (isPasswordValid)
                {
                    string query2 = "SELECT * FROM [User] WHERE Email = @EmailParam";

                    User? user = await _connection.QueryFirstOrDefaultAsync<User>(query2, new { EmailParam = email });

                    if(user is not null)
                        return user;
                }
            }
            return null;
        }



        public async Task<IEnumerable<UserEveryDTO>?> GetEvery()
        {
            // SQL pour récupérer les bonsaïs avec leurs informations associées
            string sql = @"
        SELECT u.Id AS UserId, u.Name AS UserName, u.Email, u.Role, u.IdPictureProfil,
               b.Id AS BonsaiId, b.Name AS BonsaiName, b.Description, b.IdUser AS BonsaiUserId,
               c.Id AS CategoryId, c.Shohin, c.Mame, c.Chokkan, c.Moyogi, c.Shakan,
               c.Kengai, c.HanKengai, c.Ikadabuki, c.Neagari, c.Literati, c.YoseUe,
               c.Ishitsuki, c.Kabudachi, c.Kokufu, c.Yamadori, c.Perso,
               s.Id AS StyleId, s.Chokkan AS StyleChokkan, s.Moyogi AS StyleMoyogi, s.Shakan AS StyleShakan, 
               s.Kengai AS StyleKengai, s.HanKengai AS StyleHanKengai, s.Ikadabuki AS StyleIkadabuki,
               s.Neagari AS StyleNeagari, s.Bunjin AS StyleBunjin, s.YoseUe AS StyleYoseUe,
               s.Ishitsuki AS StyleIshitsuki, s.Kabudachi AS StyleKabudachi, s.Bankan AS StyleBankan,
               s.Korabuki AS StyleKorabuki, s.Yamadori AS StyleYamadori, s.Ishituki AS StyleIshituki,
               s.Perso AS StylePerso,
               n.Id AS NoteId, n.Title, n.Description, n.CreateAt
        FROM [Bonsai] b
        LEFT JOIN [Category] c ON b.Id = c.IdBonsai
        LEFT JOIN [Style] s ON b.Id = s.IdBonsai
        LEFT JOIN [Note] n ON b.Id = n.IdBonsai
        LEFT JOIN [User] u ON b.IdUser = u.Id"; // Ajout de la jointure avec la table User

            // Exécute la requête et mappe les résultats dans la liste UserEveryDTO
            var userEveryDTOs = await _connection.QueryAsync<UserEveryDTO, BonsaiDTO, CategoryDTO, StyleDTO, NoteDTO, UserEveryDTO>(
                sql,
                (user, bonsai, category, style, note) =>
                {
                    user.Bonsai = bonsai;
                    user.Category = category;
                    user.Style = style;
                    user.Note = note;

                    return user;
                },
                splitOn: "BonsaiId,CategoryId,StyleId,NoteId");

            return userEveryDTOs;
        }



        public class UserEveryDTO
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int? IdPictureProfil { get; set; }
            public BonsaiDTO Bonsai { get; set; }
            public CategoryDTO Category { get; set; }
            public StyleDTO Style { get; set; }
            public NoteDTO Note { get; set; }
        }


        /// <summary>
        /// Met à jour la colonne IdPictureProfil de la table [User] avec la nouvelle valeur spécifiée.
        /// </summary>
        /// <param name="idUser">Identifiant de l'utilisateur à mettre à jour.</param>
        /// <param name="idPicture">Nouvelle valeur à assigner à la colonne IdPictureProfil.</param>
        /// <returns>Une tâche représentant l'opération asynchrone.</returns>
        public async Task<bool> UpdateProfilPicture(int idUser, int idPicture)
        {
            string sql = "UPDATE [User] SET IdPictureProfil = @idPicture WHERE Id = @idUser";

            int result = await _connection.ExecuteAsync(sql, new { idUser, idPicture });

            return result > 0;
        }
    }
}
