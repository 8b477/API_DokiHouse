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
            parameters.Add("@CreateAt", model.CreateAt);
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


        //public async Task<bool> UpdateProfilPicture(int idUser, int idPicture)
        //{
        //    string sql = @"
        //    UPDATE [User]
        //    SET 
        //    IdPictureProfil = @idPicture
        //    WHERE Id = @idUser";

        //    int result = await _connection.ExecuteAsync(sql, new { idUser, idPicture });

        //    return result > 0;
        //}


        public async Task<bool> Update(int id, User model)
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
