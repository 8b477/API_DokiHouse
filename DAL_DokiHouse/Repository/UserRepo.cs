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
        SET Name = @Name, Passwd = @Passwd
        WHERE Id = @id";

            DynamicParameters parameters = new();
            parameters.Add("@Name", model.Name);
            parameters.Add("@Passwd", model.Passwd);
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


    }
}
