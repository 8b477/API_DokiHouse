using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Repository;
using Entities_DokiHouse.Entities;

using Dapper;
using System.Data;


namespace DAL_DokiHouse
{
    public class UserRepo : BaseRepo<User, UserDTO, int, string>, IUserRepo
    {

        #region Constructor

        public UserRepo(IDbConnection connection) : base(connection) { }

        #endregion


        public async Task<bool> Create(UserDTO model)
        {
            string sql = @"
        INSERT INTO [User] (
            Name, Email, Passwd, Role, IdPictureProfil
        ) VALUES (
            @Name, @Email, @Passwd, @Role, @IdPictureProfil
        )";

            // Exécute la requête et récupère le nombre de lignes affectées
            int rowAffected = await _connection.ExecuteAsync(sql, model);

            return rowAffected > 0;
        }



        public async Task<bool> Update(UserDTO model)
        {
            string sql = @"
        UPDATE [User]
        SET Name = @Name, Email = @Email, Passwd = @Passwd, Role = @Role 
        WHERE Id = @id";

            DynamicParameters parameters = new();
            parameters.Add("@Name", model.Name);
            parameters.Add("@Email", model.Email);
            parameters.Add("@Passwd", model.Passwd);
            parameters.Add("@Role", model.Role);
            parameters.Add("@id", model.Id);

            int result = await _connection.ExecuteAsync(sql, parameters);

            return result > 0;
        }



        public async Task<UserDTO?> Logger(string email, string motDePasse)
        {
            string query = "SELECT Passwd FROM [User] WHERE Email = @EmailParam";

            string? hashedPassword = await _connection.QueryFirstOrDefaultAsync<string>(query, new { EmailParam = email });

            if (hashedPassword != null)
            {
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(motDePasse, hashedPassword);

                if (isPasswordValid)
                {
                    string query2 = "SELECT * FROM [User] WHERE Email = @EmailParam";

                    UserDTO? user = await _connection.QueryFirstOrDefaultAsync<UserDTO>(query2, new { EmailParam = email });

                    if(user is not null)
                        return user;
                }
            }
            return null;
        }



        public async Task<bool> UpdateProfilPicture(int idUser, int idPicture)
        {
            string sql = "UPDATE [User] SET IdPictureProfil = @idPicture WHERE Id = @idUser";

            int result = await _connection.ExecuteAsync(sql, new { idUser, idPicture });

            return result > 0;
        }



        public async Task<IEnumerable<EveryDTO>?> Infos()
        {
            // SQL pour récupérer les Users avec leurs informations associées
            string sql = @"
    SELECT 
        u.Id AS UserId, u.Name AS UserName, u.Role, u.IdPictureProfil, 
        b.Id AS BonsaiId, b.Name AS BonsaiName, b.Description AS BonsaiDescription, b.IdUser AS BonsaiUserId,
        c.Id AS CategoryId, c.Shohin, c.Mame, c.Chokkan, c.Moyogi, c.Shakan, c.Kengai, c.HanKengai, c.Ikadabuki, c.Neagari, c.Literati, c.YoseUe, c.Ishitsuki, c.Kabudachi, c.Kokufu, c.Yamadori, c.Perso AS CategoryPerso,
        s.Id AS StyleID, Bunjin, s.Bankan, s.Korabuki, s.Ishituki, s.Perso AS StylePerso, s.IdBonsai,
        n.Id AS NoteId, n.Title, n.Description AS NoteDescription, n.CreateAt, n.IdBonsai
    FROM [dbo].[User] u
    LEFT JOIN [dbo].[Bonsai] b ON u.Id = b.Id
    LEFT JOIN [dbo].[Category] c ON b.Id = c.Id
    LEFT JOIN [dbo].[Style] s ON b.Id = s.IdBonsai
    LEFT JOIN [dbo].[Note] n ON b.Id = n.IdBonsai";

            //Ici je map
            var fullInfosUser = await _connection.QueryAsync<UserJoinDTO, BonsaiJoinDTO, CategoryJoinDTO, StyleJoinDTO, NoteJoinDTO, EveryDTO>(
                sql,
                (user, bonsai, category, style, note) =>
                {
                    var every = new EveryDTO
                    {
                        User = new UserJoinDTO // Ici User ne peut pas être null
                        {
                            UserId = user.UserId,
                            UserName = user.UserName,
                            Role = user.Role,
                            IdPictureProfil = user.IdPictureProfil
                        },
                        Bonsai = bonsai != null ? new BonsaiJoinDTO
                        {
                            BonsaiId = bonsai.BonsaiId,
                            BonsaiName = bonsai.BonsaiName,
                            BonsaiDescription = bonsai.BonsaiDescription,
                            BonsaiUserId = bonsai.BonsaiUserId
                        } : null,
                        Category = category != null ? new CategoryJoinDTO
                        {
                            CategoryId = category.CategoryId,
                            Shohin = category.Shohin,
                            Mame = category.Mame,
                            Chokkan = category.Chokkan,
                            Moyogi = category.Moyogi,
                            Shakan = category.Shakan,
                            Kengai = category.Kengai,
                            HanKengai = category.HanKengai,
                            Ikadabuki = category.Ikadabuki,
                            Neagari = category.Neagari,
                            Literati = category.Literati,
                            YoseUe = category.YoseUe,
                            Ishitsuki = category.Ishitsuki,
                            Kabudachi = category.Kabudachi,
                            Kokufu = category.Kokufu,
                            Yamadori = category.Yamadori,
                            CategoryPerso = category.CategoryPerso
                        } : null,
                        Style = style != null ? new StyleJoinDTO
                        {
                            StyleId = style.StyleId,
                            Bunjin = style.Bunjin,
                            Bankan = style.Bankan,
                            Korabuki = style.Korabuki,
                            Ishituki = style.Ishituki,
                            StylePerso = style.StylePerso
                        } : null,
                        Note = note != null ? new NoteJoinDTO
                        {
                            NoteId = note.NoteId,
                            Title = note.Title,
                            NoteDescription = note.NoteDescription,
                            CreateAt = note.CreateAt
                        } : null
                    };
                    return every;
                },
                splitOn: "bonsaiId,categoryId,styleId,noteId"
            );
            return fullInfosUser;
        }


    }
}
