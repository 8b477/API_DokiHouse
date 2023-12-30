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


        public async Task<bool> Create(BonsaiDTO bonsai)
        {
            string sql = "INSERT INTO [Bonsai] (Name, Description, IdUser) VALUES (@Name, @Description, @IdUser)";

            var parameters = new
            {
                Name = bonsai.Name,
                Description = bonsai.Description,
                IdUser = bonsai.IdUser
            };

            int insertedId = await _connection.ExecuteScalarAsync<int>(sql, parameters);

            return insertedId > 0;
        }

    }
}
