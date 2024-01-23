using DAL_DokiHouse.Interfaces;
using DAL_DokiHouse.Repository.Generic;

using Dapper;
using Entities_DokiHouse.Entities;

using System.Data;
using System.Data.Common;


namespace DAL_DokiHouse.Repository
{
    public class PictureBonsaiRepo : BaseRepo<PictureBonsai, int, string>, IPictureBonsaiRepo
    {

        #region Injection
        public PictureBonsaiRepo(IDbConnection connection) : base(connection) { }

        #endregion


        public async Task<bool> AddPictureBonsai(int idBonsai, PictureBonsai picture)
        {
            string sql = @"
            INSERT INTO PictureBonsai (FileName, CreateAt, ModifiedAt, IdBonsai)
            VALUES (@FileName, @CreateAt, @ModifiedAt, @IdBonsai)";

            DynamicParameters parameters = new();
            parameters.Add("@FileName", picture.FileName);
            parameters.Add("@CreateAt", picture.CreateAt);
            parameters.Add("@ModifiedAt", picture.ModifiedAt);
            parameters.Add("@IdBonsai", idBonsai);


            int rowAffected = await _connection.ExecuteAsync(sql, parameters);

            return rowAffected > 0;
        }

    }
}