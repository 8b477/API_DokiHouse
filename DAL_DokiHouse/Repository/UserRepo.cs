using Entities_DokiHouse.Entities;
using Dapper;
using System.Data;
using DAL_DokiHouse.DTO.User;
using DAL_DokiHouse.DTO.Bonsai;
using DAL_DokiHouse.Repository.Generic;


namespace DAL_DokiHouse
{
    public class UserRepo : BaseRepo<User, int, string>, IUserRepo
    {

        #region Injection
        public UserRepo(IDbConnection connection) : base(connection) { }

        #endregion



        public async Task<bool> Create(User model)
        {
            string sql = @"
            INSERT INTO [User] 
            (Name, Email, Passwd, Role, CreateAt, ModifiedAt)
            VALUES (@Name, @Email, @Passwd, @Role, @CreateAt, @ModifiedAt)";

            DynamicParameters parameters = new();
            parameters.Add("@Name", model.Name);
            parameters.Add("@Email", model.Email);
            parameters.Add("@Passwd", model.Passwd);
            parameters.Add("@Role", model.Role);
            parameters.Add("@CreateAt", model.CreatedAt);
            parameters.Add("@ModifiedAt", model.ModifiedAt);

            int rowAffected = await _connection.ExecuteAsync(sql, parameters);

            return rowAffected > 0;
        }


        public async Task<bool> UpdateName(int idUser, User model)
        {
            string sql = @"
            UPDATE [User]
            SET
            Name = @Name,
            ModifiedAt = @ModifiedAt
            WHERE Id = @id";

            DynamicParameters parameters = new();
            parameters.Add("@Name", model.Name);
            parameters.Add("@ModifiedAt", model.ModifiedAt);
            parameters.Add("@id", idUser);

            int result = await _connection.ExecuteAsync(sql, parameters);

            return result > 0;
        }


        public async Task<bool> UpdatePass(int idUser, User model)
        {
            string sql = @"
            UPDATE [User]
            SET 
            Passwd = @Passwd,
            ModifiedAt = @ModifiedAt
            WHERE Id = @id";

            DynamicParameters parameters = new();
            parameters.Add("@Passwd", model.Passwd);
            parameters.Add("@ModifiedAt", model.ModifiedAt);
            parameters.Add("@id", idUser);

            int result = await _connection.ExecuteAsync(sql, parameters);

            return result > 0;
        }


        public async Task<bool> UpdateEmail(int idUser, User model)
        {
            string sql = @"
            UPDATE [User]
            SET 
            Email = @Email,
            ModifiedAt = @ModifiedAt
            WHERE Id = @id";

            DynamicParameters parameters = new();
            parameters.Add("@Email", model.Email);
            parameters.Add("@ModifiedAt", model.ModifiedAt);
            parameters.Add("@id", idUser);

            int result = await _connection.ExecuteAsync(sql, parameters);

            return result > 0;
        }


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

                    if (user is not null)
                        return user;
                }
            }
            return null;
        }


        // =====> IN PROGRESS !!!!!!!!!!!
        public async Task<bool> UpdateProfilPicture(int idUser, int idPicture)
        {
            string sql = @"
            UPDATE [User]
            SET 
            IdPictureProfil = @idPicture
            WHERE Id = @idUser";

            int result = await _connection.ExecuteAsync(sql, new { idUser, idPicture });

            return result > 0;
        }


        public async Task<bool> Update(int id,User model)
        {
            string sql = @"
                UPDATE [User]
                SET 
                Name = @Name,
                Email = @Email,
                Passwd = @Passwd,
                ModifiedAt = @ModifiedAt
                WHERE Id = @id";

            DynamicParameters parameters = new();
            parameters.Add("@Name", model.Name);
            parameters.Add("@Email", model.Email);
            parameters.Add("@Passwd", model.Passwd);
            parameters.Add("@ModifiedAt", model.ModifiedAt);
            parameters.Add("@id", id);

            int result = await _connection.ExecuteAsync(sql, parameters);

            return result > 0;
        }


        public async Task<IEnumerable<UserAndBonsaiDetails?>> GetInfos(int startIndex, int pageSize)
        {
            string sql = @"
            SELECT 
            u.Id, u.Name,

            pu.Id, pu.Avatar, pu.CreateAt, pu.ModifiedAt,
            b.Id, b.Name, b.IdUser,

            pb.Id, pb.FileName, pb.CreateAt, pb.ModifiedAt, pb.IdBonsai,

            c.Id, c.Shohin, c.Mame, c.Chokkan, c.Moyogi, c.Shakan, c.Kengai, c.HanKengai, c.Ikadabuki, c.Neagari,
            c.Literati, c.YoseUe, c.Ishitsuki,  c.Kabudachi, c.Kokufu, c.Yamadori, c.Perso AS CatePerso, c.IdBonsai,

            s.Id, s.Bunjin, s.Bankan, s.Korabuki, s.Ishituki, s.Perso AS StylePerso, s.IdBonsai,

            n.Id, n.Title, n.Description, n.CreateAt, n.IdBonsai

            FROM [dbo].[User] u
            LEFT JOIN [dbo].[PictureProfil] pu ON pu.IdUser = u.Id
            LEFT JOIN [dbo].[Bonsai] b ON b.IdUser = u.Id
            LEFT JOIN [dbo].[PictureBonsai] pb ON pb.IdBonsai = b.Id
            LEFT JOIN [dbo].[Category] c ON c.IdBonsai = b.Id
            LEFT JOIN [dbo].[Style] s ON s.IdBonsai = b.Id
            LEFT JOIN [dbo].[Note] n ON n.IdBonsai = b.Id
            ORDER BY u.Id
            OFFSET @StartIndex ROWS FETCH NEXT @PageSize ROWS ONLY";

            var userDictionary = new Dictionary<int, UserAndBonsaiDetails>();

            await _connection.QueryAsync<UserAndBonsaiDetails, PictureProfil, BonsaiDetailsDTO, PictureBonsai, Category, Style, Note, UserAndBonsaiDetails>(
                sql,
                (user, pictureProfil, bonsai, pictureBonsai, category, style, note) =>
                {
                    if (!userDictionary.TryGetValue(user.Id, out var existingUser))
                    {
                        existingUser = user;
                        existingUser.BonsaiDetails = new List<BonsaiDetailsDTO>();
                        userDictionary.Add(existingUser.Id, existingUser);
                    }

                    user.PictureProfil = pictureProfil;

                    if (bonsai is not null)
                    {
                        bonsai.PictureBonsai = pictureBonsai;
                        bonsai.Categories = category;
                        bonsai.Styles = style;
                        bonsai.Notes = note;
                    }

                    if (existingUser.BonsaiDetails is not null)
                    {
                        // Ajoute le bonsai uniquement s'il n'existe pas déjà dans la liste, pour éviter les doublons
                        if (bonsai is not null && !existingUser.BonsaiDetails.Any(b => b.Id == bonsai.Id))
                        {
                            existingUser.BonsaiDetails.Add(bonsai);
                        }
                    }

                    return existingUser;
                }, new {StartIndex = startIndex, PageSize = pageSize},
                splitOn: "Id");

            return userDictionary.Values;
        }

     
        public async Task<UserAndBonsaiDetails?> GetInfosById(int idUser)
        {
            string sql = @"
            SELECT 
            u.Id, u.Name,

            pu.Id, pu.Avatar, pu.CreateAt, pu.ModifiedAt,
            b.Id, b.Name, b.IdUser,

            pb.Id, pb.FileName, pb.CreateAt, pb.ModifiedAt, pb.IdBonsai,

            c.Id, c.Shohin, c.Mame, c.Chokkan, c.Moyogi, c.Shakan, c.Kengai, c.HanKengai, c.Ikadabuki, c.Neagari,
            c.Literati, c.YoseUe, c.Ishitsuki,  c.Kabudachi, c.Kokufu, c.Yamadori, c.Perso AS CatePerso, c.IdBonsai,

            s.Id, s.Bunjin, s.Bankan, s.Korabuki, s.Ishituki, s.Perso AS StylePerso, s.IdBonsai,

            n.Id, n.Title, n.Description, n.CreateAt, n.IdBonsai

            FROM [dbo].[User] u
            LEFT JOIN [dbo].[PictureProfil] pu ON pu.IdUser = u.Id
            LEFT JOIN [dbo].[Bonsai] b ON b.IdUser = u.Id
            LEFT JOIN [dbo].[PictureBonsai] pb ON pb.IdBonsai = b.Id
            LEFT JOIN [dbo].[Category] c ON c.IdBonsai = b.Id
            LEFT JOIN [dbo].[Style] s ON s.IdBonsai = b.Id
            LEFT JOIN [dbo].[Note] n ON n.IdBonsai = b.Id
            WHERE u.Id = @IdUser";

            var userDictionary = new Dictionary<int, UserAndBonsaiDetails>();

            await _connection.QueryAsync<UserAndBonsaiDetails, PictureProfil, BonsaiDetailsDTO, PictureBonsai, Category, Style, Note, UserAndBonsaiDetails>(
                sql,
                (user, pictureProfil, bonsai, pictureBonsai, category, style, note) =>
                {
                    if (!userDictionary.TryGetValue(user.Id, out var existingUser))
                    {
                        existingUser = user;
                        existingUser.BonsaiDetails = new List<BonsaiDetailsDTO>();
                        userDictionary.Add(existingUser.Id, existingUser);
                    }

                    user.PictureProfil = pictureProfil;

                    if(bonsai is not null)
                    {
                        bonsai.PictureBonsai = pictureBonsai;
                        bonsai.Categories = category;
                        bonsai.Styles = style;
                        bonsai.Notes = note;
                    }

                    if(existingUser.BonsaiDetails is not null)
                    {
                        // Ajoute le bonsai uniquement s'il n'existe pas déjà dans la liste, pour éviter les doublons
                        if (bonsai is not null && !existingUser.BonsaiDetails.Any(b => b.Id == bonsai.Id))
                        {
                            existingUser.BonsaiDetails.Add(bonsai);
                        }
                    }

                    return existingUser;
                },
                new { IdUser = idUser },
                splitOn: "Id");

            return userDictionary.Values.FirstOrDefault();
        }


        public async Task<IEnumerable<UserAndPictureDTO>> GetUsers(int startIndex, int pageSize)
        {
            string sql = @"
                        SELECT 
                        u.Id, u.Name, u.Role, u.CreateAt, u.ModifiedAt,
                        p.Id, p.Avatar, p.CreateAt, p.ModifiedAt
                        FROM [User] AS u
                        LEFT JOIN [PictureProfil] p ON p.IdUser = u.Id
                        ORDER BY u.Id
                        OFFSET @StartIndex ROWS FETCH NEXT @PageSize ROWS ONLY";

            var item = await _connection.QueryAsync<UserAndPictureDTO, PictureProfil, UserAndPictureDTO>(sql,
                    (user, picture) =>
                    {
                        user.PictureProfil = picture;

                        return user;
                    },
                    new {StartIndex = startIndex, PageSize = pageSize},
                    splitOn : "Id"
                );

            return item;
        }


        public async Task<UserAndPictureDTO?> GetUser(int idUser)
        {
            string sql = @"
                        SELECT 
                        u.Id, u.Name, u.Role, u.CreateAt, u.ModifiedAt,
                        p.Id, p.Avatar, p.CreateAt, p.ModifiedAt
                        FROM [User] AS u
                        LEFT JOIN [PictureProfil] p ON p.IdUser = u.Id
                        WHERE u.Id = @IdUser";

            var item = await _connection.QueryAsync<UserAndPictureDTO, PictureProfil, UserAndPictureDTO>(sql,
                    (user, picture) =>
                    {
                        user.PictureProfil = picture;

                        return user;
                    },
                    new { IdUser = idUser },
                    splitOn: "Id"
                );

            return item.FirstOrDefault();
        }


    }
}
