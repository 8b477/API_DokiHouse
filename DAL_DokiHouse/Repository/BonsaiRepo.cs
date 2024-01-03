using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;
using Dapper;

using Entities_DokiHouse.Entities;

using System.Data;

namespace DAL_DokiHouse.Repository
{
    public class BonsaiRepo : BaseRepo<Bonsai, BonsaiDTO, int, string>, IBonsaiRepo
    {

        #region Injection
        public BonsaiRepo(IDbConnection connection) : base(connection){}
        #endregion


        public async Task<bool> Create(BonsaiDTO model)
        {
            string sql = @"
        INSERT INTO [Bonsai] (
            Name, Description, IdUser
        ) VALUES (
            @Name, @Description, @IdUser
        )";

            // Exécute la requête et récupère le nombre de lignes affectées
            int rowAffected = await _connection.ExecuteAsync(sql, model);

            return rowAffected > 0;
        }



        public async Task<bool> Update(BonsaiDTO bonsai)
        {
            string sql = "UPDATE [Bonsai] SET Name = @Name, Description = @Description WHERE IdUser = @id";

            DynamicParameters parameters = new();
            parameters.Add("@Name", bonsai.Name);
            parameters.Add("@Description", bonsai.Description);
            parameters.Add("@id", bonsai.IdUser);

            int result = await _connection.ExecuteAsync(sql, parameters);

            return result > 0;
        }



        public async Task<IEnumerable<BonsaiDTO>> Get(int idUser)
        {
            string sql = @"
        SELECT *
        FROM [Bonsai]
        WHERE IdUser = @id";

            IEnumerable<BonsaiDTO> BonsaiCollections = await _connection.QueryAsync<BonsaiDTO>(sql, new { id = idUser });

            return BonsaiCollections;
        }


    }
}
