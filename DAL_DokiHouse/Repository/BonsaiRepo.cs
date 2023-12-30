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
                bonsai.Name,
                bonsai.Description,
                bonsai.IdUser
            };

            int insertedId = await _connection.ExecuteAsync(sql, parameters);

            return insertedId > 0;
        }
        
        public async Task<bool> UpdateBonsai(BonsaiDTO bonsai)
        {
            string sql = "UPDATE [Bonsai] SET Name = @Name,Description = @Description WHERE Id = @id";

            DynamicParameters parameters = new();
            parameters.Add("@Name",bonsai.Name);
            parameters.Add("@Description",bonsai.Description);
            parameters.Add("@id", bonsai.Id);

            int result = await _connection.ExecuteAsync(sql, parameters);

            return result > 0;

        }
    }
}
