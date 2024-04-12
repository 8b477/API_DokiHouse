using DAL_DokiHouse.Interfaces;
using DAL_DokiHouse.Repository.Generic;
using Dapper;
using Entities_DokiHouse.Entities;
using Entities_DokiHouse.Interfaces;

using System.Data;

namespace DAL_DokiHouse.Repository
{
    public class BonsaiRepo : BaseRepo<Bonsai, int, string>, IBonsaiRepo
    {

        #region Injection
        public BonsaiRepo(IDbConnection connection) : base(connection) {}

        #endregion


        public async Task<int> Create(Bonsai model, int idUser)
        {
            string sql = @"
                INSERT INTO [Bonsai]
                (Name, Description, IdUser, CreateAt, ModifiedAt) 
                VALUES (@Name, @Description, @IdUser, @CreateAt, @ModifiedAt);
                SELECT SCOPE_IDENTITY();";

            DynamicParameters parameters = new();
            parameters.Add("@Name", model.Name);
            parameters.Add("@Description", model.Description);
            parameters.Add("@IdUser", idUser);
            parameters.Add("@CreateAt", model.CreateAt);
            parameters.Add("@ModifiedAt", model.ModifiedAt);

            int idBonsai = await _connection.QuerySingleOrDefaultAsync<int>(sql, parameters);

            return idBonsai;
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


        public async Task<IEnumerable<BonsaiPictureDTO>?> GetBonsaiAndPicture(int idUser)
        {
            string sql = @"
            SELECT
                b.Id AS IdBonsai,
                b.IdUser,
                b.Name AS BonsaiName,
                b.Description AS BonsaiDescription,
                b.CreateAt,
                b.ModifiedAt,

                pb.Id AS IdPicture,
                pb.FileName,
                pb.CreateAt,
                pb.ModifiedAt,
                pb.IdBonsai

            FROM [Bonsai] b
            LEFT JOIN [dbo].[PictureBonsai] pb ON pb.IdBonsai = b.Id
            WHERE b.IdUser = @idUserP";

            Dictionary<int, BonsaiPictureDTO> bonsaiDico = new();

            var bonsaiCollection = await _connection.QueryAsync<BonsaiPictureDTO, PictureBonsaiDTO, BonsaiPictureDTO>(sql,
                (bonsai, picture) =>
                    {
                        if (!bonsaiDico.TryGetValue(bonsai.IdBonsai, out var bonsaiEntry))
                        {
                            bonsaiEntry = bonsai;
                            bonsaiEntry.BonsaiPicture = new List<PictureBonsaiDTO>();
                            bonsaiDico.Add(bonsaiEntry.IdBonsai, bonsaiEntry);
                        }

                        if (picture != null)
                        {
                            bonsaiEntry.BonsaiPicture.Add(picture);
                        }

                        return bonsaiEntry;
                    },
                new { idUserP = idUser},
            splitOn: "IdPicture"
        );

            return bonsaiCollection.Distinct();
        }


        public async Task<IEnumerable<BonsaiPictureDTO>?> GetAllBonsaiAndPicture()
        {
            string sql = @"
            SELECT
                b.Id AS IdBonsai,
                b.IdUser,
                b.Name AS BonsaiName,
                b.Description AS BonsaiDescription,
                b.CreateAt,
                b.ModifiedAt,

                pb.Id AS IdPicture,
                pb.FileName,
                pb.CreateAt,
                pb.ModifiedAt,
                pb.IdBonsai

            FROM [Bonsai] b
            LEFT JOIN [dbo].[PictureBonsai] pb ON pb.IdBonsai = b.Id";

            Dictionary<int, BonsaiPictureDTO> bonsaiDico = new();

            var bonsaiCollection = await _connection.QueryAsync<BonsaiPictureDTO, PictureBonsaiDTO, BonsaiPictureDTO>(sql,
                (bonsai, picture) =>
                {
                    if (!bonsaiDico.TryGetValue(bonsai.IdBonsai, out var bonsaiEntry))
                    {
                        bonsaiEntry = bonsai;
                        bonsaiEntry.BonsaiPicture = new List<PictureBonsaiDTO>();
                        bonsaiDico.Add(bonsaiEntry.IdBonsai, bonsaiEntry);
                    }

                    if (picture != null)
                    {
                        bonsaiEntry.BonsaiPicture.Add(picture);
                    }

                    return bonsaiEntry;
                },
            splitOn: "IdPicture"
        );

            return bonsaiCollection.Distinct();
        }
    }
}

public class BonsaiPictureDTO
{
    public int IdBonsai { get; set; }
    public int IdUser { get; set; }
    public string BonsaiName { get; set; } = string.Empty;
    public string BonsaiDescription { get; set; } = string.Empty;
    public DateTime CreateAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public List<PictureBonsaiDTO>? BonsaiPicture { get; set; }
}

public class PictureBonsaiDTO
{
    public int IdPicture { get; set; }
    public string FileName { get; set; } = string.Empty;
    public DateTime CreateAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public int IdBonsai { get; set; }
}