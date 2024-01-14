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
            Name, Email, Passwd, Role, CreateAt, ModifiedAt
        ) VALUES (
            @Name, @Email, @Passwd, @Role, @CreateAt, @ModifiedAt
        )";

            DynamicParameters parameters = new();
            parameters.Add("@Name", model.Name);
            parameters.Add("@Email", model.Email);
            parameters.Add("@Passwd", model.Passwd);
            parameters.Add("@Role", model.Role);
            parameters.Add("@CreateAt", model.CreatedAt);
            parameters.Add("@ModifiedAt", model.ModifiedAt);

            // Exécute la requête et récupère le nombre de lignes affectées
            int rowAffected = await _connection.ExecuteAsync(sql, parameters);

            return rowAffected > 0;
        }


        public async Task<bool> UpdateName(UserUpNameDTO model)
        {
            string sql = @"
        UPDATE [User]
        SET Name = @Name
        WHERE Id = @id";

            DynamicParameters parameters = new();
            parameters.Add("@Name", model.Name);
            parameters.Add("@id", model.Id);

            int result = await _connection.ExecuteAsync(sql, parameters);

            return result > 0;
        }


        public async Task<bool> UpdatePass(UserUpPassDTO model)
        {
            string sql = @"
        UPDATE [User]
        SET Passwd = @Passwd
        WHERE Id = @id";

            DynamicParameters parameters = new();
            parameters.Add("@Passwd", model.Passwd);
            parameters.Add("@id", model.Id);

            int result = await _connection.ExecuteAsync(sql, parameters);

            return result > 0;
        }


        public async Task<bool> UpdateEmail(UserUpMailDTO model)
        {
            string sql = @"
        UPDATE [User]
        SET Email = @Email
        WHERE Id = @id";

            DynamicParameters parameters = new();
            parameters.Add("@Email", model.Email);
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

                    if (user is not null)
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


        public async Task<IEnumerable<UserDetailsBonsaiDTO?>> GetInfos(int startIndex, int pageSize)
        {

            string sql = @"
            SELECT 
                u.Id AS IdUser,
                u.Name,

                pu.Id,
                pu.Avatar,
                pu.CreateAt,
                pu.ModifiedAt,

                b.Id,
                b.Name,
                b.IdUser,

                pb.Id,
                pb.FileName,
                pb.CreateAt,
                pb.ModifiedAt,
                pb.IdBonsai,

                c.Id,
                c.Shohin,
                c.Mame,
                c.Chokkan,
                c.Moyogi,
                c.Shakan,
                c.Kengai,
                c.HanKengai,
                c.Ikadabuki,
                c.Neagari,
                c.Literati,
                c.YoseUe,
                c.Ishitsuki,
                c.Kabudachi,
                c.Kokufu,
                c.Yamadori,
                c.Perso AS CatePerso,
                c.IdBonsai,

                s.Id,
                Bunjin,
                s.Bankan,
                s.Korabuki,
                s.Ishituki,
                s.Perso AS StylePerso,
                s.IdBonsai,

                n.Id,
                n.Title,
                n.Description,
                n.CreateAt,
                n.IdBonsai

            FROM [dbo].[User] u
            LEFT JOIN [dbo].[PictureProfil] pu ON pu.IdUser = u.Id
            JOIN [dbo].[Bonsai] b ON b.IdUser = u.Id
            LEFT JOIN [dbo].[PictureBonsai] pb ON pb.IdBonsai = b.Id
            LEFT JOIN [dbo].[Category] c ON c.IdBonsai = b.Id
            LEFT JOIN [dbo].[Style] s ON s.IdBonsai = b.Id
            LEFT JOIN [dbo].[Note] n ON n.IdBonsai = b.Id
            ORDER BY b.Id
            OFFSET @StartIndex ROWS FETCH NEXT @PageSize ROWS ONLY";

            var users = await _connection.QueryAsync<UserDetailsBonsaiDTO, PictureProfil, BonsaiDetailsDTO, PictureBonsai, Category, Style, Note, UserDetailsBonsaiDTO>(
                    sql,
                    (user, pictureProfil, bonsai, pictureBonsai, category, style, note) =>
                    {
                        user.PictureProfil = pictureProfil;
                        bonsai.PictureBonsai = pictureBonsai;
                        bonsai.Categories = category;
                        bonsai.Styles = style;
                        bonsai.Notes = note;

                        user.Bonsais ??= new List<BonsaiDetailsDTO>();
                        user.Bonsais.Add(bonsai);

                        return user;
                    },
                    new { StartIndex = startIndex, PageSize = pageSize },
                    splitOn: "Id, Id, Id, Id, Id, Id");

            // GroupBy pour éliminer les doublons basés sur UserId
            return users.GroupBy(user => user.IdUser).Select(group => group.First());
        }


        public async Task<UserDetailsBonsaiDTO?> GetInfosById(int idUser)
        {
            string sql = @"
            SELECT 
                u.Id AS IdUser,
                u.Name,

                pu.Id,
                pu.Avatar,
                pu.CreateAt,
                pu.ModifiedAt,

                b.Id,
                b.Name,
                b.IdUser,

                pb.Id,
                pb.FileName,
                pb.CreateAt,
                pb.ModifiedAt,
                pb.IdBonsai,

                c.Id,
                c.Shohin,
                c.Mame,
                c.Chokkan,
                c.Moyogi,
                c.Shakan,
                c.Kengai,
                c.HanKengai,
                c.Ikadabuki,
                c.Neagari,
                c.Literati,
                c.YoseUe,
                c.Ishitsuki,
                c.Kabudachi,
                c.Kokufu,
                c.Yamadori,
                c.Perso AS CatePerso,
                c.IdBonsai,

                s.Id,
                Bunjin,
                s.Bankan,
                s.Korabuki,
                s.Ishituki,
                s.Perso AS StylePerso,
                s.IdBonsai,

                n.Id,
                n.Title,
                n.Description,
                n.CreateAt,
                n.IdBonsai

            FROM [dbo].[User] u
            LEFT JOIN [dbo].[PictureProfil] pu ON pu.IdUser = u.Id
            JOIN [dbo].[Bonsai] b ON b.IdUser = u.Id
            LEFT JOIN [dbo].[PictureBonsai] pb ON pb.IdBonsai = b.Id
            LEFT JOIN [dbo].[Category] c ON c.IdBonsai = b.Id
            LEFT JOIN [dbo].[Style] s ON s.IdBonsai = b.Id
            LEFT JOIN [dbo].[Note] n ON n.IdBonsai = b.Id
            WHERE u.Id = @IdUser";

            var userDictionary = new Dictionary<int, UserDetailsBonsaiDTO>();

            await _connection.QueryAsync<UserDetailsBonsaiDTO, PictureProfil, BonsaiDetailsDTO, PictureBonsai, Category, Style, Note, UserDetailsBonsaiDTO>(
                sql,
                (user, pictureProfil, bonsai, pictureBonsai, category, style, note) =>
                {
                    if (!userDictionary.TryGetValue(user.IdUser, out var existingUser))
                    {
                        existingUser = user;
                        existingUser.Bonsais = new List<BonsaiDetailsDTO>();
                        userDictionary.Add(existingUser.IdUser, existingUser);
                    }

                    user.PictureProfil = pictureProfil;
                    bonsai.PictureBonsai = pictureBonsai;
                    bonsai.Categories = category;
                    bonsai.Styles = style;
                    bonsai.Notes = note;

                    // Ajoute le bonsai uniquement s'il n'existe pas déjà dans la liste, pour éviter les doublons
                    if (!existingUser.Bonsais.Any(b => b.Id == bonsai.Id))
                    {
                        existingUser.Bonsais.Add(bonsai);
                    }

                    return existingUser;
                },
                new { IdUser = idUser },
                splitOn: "Id, Id, Id, Id, Id, Id");

            return userDictionary.Values.FirstOrDefault();
        }


        public new async Task<IEnumerable<UserAndPictureDTO>> Get()
        {
            string sql = @"
                        SELECT 
                        u.Id, u.Name, u.Role, u.CreateAt, u.ModifiedAt,
                        p.Id, p.Avatar AS Avatar, p.CreateAt, p.ModifiedAt
                        FROM [User] AS u
                        LEFT JOIN [PictureProfil] p ON p.IdUser = u.Id";

            var item = await _connection.QueryAsync<UserAndPictureDTO, PictureProfil, UserAndPictureDTO>(sql,
                    (user, picture) =>
                    {
                        user.PictureProfil = picture;

                        return user;
                    },
                    splitOn : "Id"
                );

            return item;
        }


    }
}
