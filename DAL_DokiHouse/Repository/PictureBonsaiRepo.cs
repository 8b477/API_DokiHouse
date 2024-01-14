using DAL_DokiHouse.Interfaces;
using Dapper;
using Entities_DokiHouse.Entities;
using System.Data.Common;


namespace DAL_DokiHouse.Repository
{
    public class PictureBonsaiRepo : IPictureBonsaiRepo
    {

        #region Injection
        private readonly DbConnection _connection;

        public PictureBonsaiRepo(DbConnection connection) => _connection = connection;
        #endregion


        public async Task<bool> AddPictureBonsai(PictureBonsai picture)
        {
            string sql = @"
            INSERT INTO PictureBonsai (FileName, CreateAt, ModifiedAt, IdBonsai)
            VALUES (@FileName, @CreateAt, @ModifiedAt, @IdBonsai)";

            DynamicParameters parameters = new();
            parameters.Add("@FileName", picture.FileName);
            parameters.Add("@CreateAt", picture.CreatedAt);
            parameters.Add("@ModifiedAt", picture.ModifiedAt);
            parameters.Add("@IdBonsai", picture.IdBonsai);


            int rowAffected = await _connection.ExecuteAsync(sql, parameters);

            return rowAffected > 0;
        }

    }
}