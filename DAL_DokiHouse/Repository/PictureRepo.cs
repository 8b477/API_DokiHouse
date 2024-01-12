using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;
using Dapper;
using System.Data;
using System.Reflection;


namespace DAL_DokiHouse.Repository
{
    public class PictureRepo : IPictureRepo
    {

        #region injection
        private readonly IDbConnection _connection;

        public PictureRepo(IDbConnection connection) => (_connection) = (connection);
        #endregion


        public async Task<bool> AddPictureBonsai(PictureBonsaiDTO picture)
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



/*
 



        public async Task<byte[]?> GetImageProfil(int idPicture)
        {
            byte[]? imageData = await _connection.QueryFirstOrDefaultAsync<byte[]?>("SELECT Picture FROM[PictureProfil] WHERE Id = @idParam", new {idParam = idPicture});

            return imageData;
        }




        public async Task<IEnumerable<byte[]?>> GetImageBonsai(int idUser)
        {
            IEnumerable<byte[]?> imageData = await _connection.QueryAsync<byte[]?>("SELECT Picture FROM[PictureBonsai] WHERE Id = @idParam", new { idParam = idUser });

            return imageData;
        }


        public async Task<int> AddPictureProfil(IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            byte[] pictureConvert = memoryStream.ToArray();

            string sql = "INSERT INTO [PictureProfil] (Picture) OUTPUT INSERTED.Id VALUES (@Picture)";

            int? generatedId = await _connection.QueryFirstOrDefaultAsync<int?>(sql, new { Picture = pictureConvert });

            return generatedId ?? 0;
        }


 */