using DAL_DokiHouse.Interfaces;
using DAL_DokiHouse.Repository.Generic;
using Dapper;
using Entities_DokiHouse.Entities;
using System.Data;

namespace DAL_DokiHouse.Repository
{
    public class BonsaiRepo : BaseRepo<Bonsai, int, string>, IBonsaiRepo
    {

        #region Injection
        public BonsaiRepo(IDbConnection connection) : base(connection) {}

        #endregion


        public async Task<bool> Create(Bonsai model, int idUser)
        {
            string sql = @"
            INSERT INTO [Bonsai]
            (Name, Description, IdUser, CreateAt, ModifiedAt) 
            VALUES (@Name, @Description, @IdUser, @CreateAt, @ModifiedAt)";

            DynamicParameters parameters = new();
            parameters.Add("@Name",model.Name);
            parameters.Add("@Description", model.Description);
            parameters.Add("@IdUser", idUser);
            parameters.Add("@CreateAt", model.CreateAt);
            parameters.Add("@ModifiedAt", model.ModifiedAt);

            int rowAffected = await _connection.ExecuteAsync(sql, parameters);

            return rowAffected > 0;
        }


        public async Task<bool> Update(Bonsai bonsai, int idBonsai)
        {
            string sql = @"
            UPDATE [Bonsai] 
            SET Name = @Name, Description = @Description 
            WHERE IdUser = @id";

            DynamicParameters parameters = new();
            parameters.Add("@Name", bonsai.Name);
            parameters.Add("@Description", bonsai.Description);
            parameters.Add("@id", idBonsai);

            int result = await _connection.ExecuteAsync(sql, parameters);

            return result > 0;
        }


        public async Task<IEnumerable<Bonsai>?> GetOwnBonsai(int id)
        {
            string sql = @"SELECT * FROM [Bonsai] WHERE IdUser = @idParam";

            IEnumerable<Bonsai> bonsaiCollection = await _connection.QueryAsync<Bonsai>(sql, new {idParam = id});

            return bonsaiCollection;
        }

    }
}
