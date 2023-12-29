using DAL_DokiHouse.Interfaces;

using Dapper;
using Microsoft.AspNetCore.Http;
using System.Data;


namespace DAL_DokiHouse.Repository
{
    public class PictureRepo : IPictureRepo
    {

        #region injection
        private readonly IDbConnection _connection;

        public PictureRepo(IDbConnection connection) => (_connection) = (connection);
        #endregion

        /// <summary>
        /// Ajoute une image de profil à la table [PictureProfil] dans la base de données.
        /// </summary>
        /// <param name="file">Fichier image à ajouter.</param>
        /// <returns>L'identifiant généré de l'image ajoutée.</returns>
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


        /// <summary>
        /// Ajoute une image de bonsaï à la table [PictureBonsai] dans la base de données.
        /// </summary>
        /// <param name="file">Fichier image à ajouter.</param>
        /// <returns>L'identifiant généré de l'image ajoutée.</returns>
        public async Task<int> AddPictureBonsai(IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            byte[] pictureConvert = memoryStream.ToArray();

            string sql = "INSERT INTO [PictureBonsai] (Picture) OUTPUT INSERTED.Id VALUES (@Picture)";

            int? generatedId = await _connection.QueryFirstOrDefaultAsync<int?>(sql, new { Picture = pictureConvert });

            return generatedId ?? 0;
        }


        /// <summary>
        /// Récupère l'image de profil associée à l'identifiant spécifié depuis la table [PictureProfil].
        /// </summary>
        /// <param name="idPicture">Identifiant de l'image à récupérer.</param>
        /// <returns>Les données de l'image de profil ou null si l'image n'est pas trouvée.</returns>
        public async Task<byte[]?> GetImageProfil(int idPicture)
        {
            byte[]? imageData = await _connection.QueryFirstOrDefaultAsync<byte[]?>("SELECT Picture FROM[PictureProfil] WHERE Id = @idParam", new {idParam = idPicture});

            return imageData;
        }


        /// <summary>
        /// Récupère les images de bonsaï associées à l'utilisateur spécifié depuis la table [PictureBonsai].
        /// </summary>
        /// <param name="idUser">Identifiant de l'utilisateur dont les images de bonsaï doivent être récupérées.</param>
        /// <returns>Une collection des données d'images de bonsaï associées à l'utilisateur ou null si pas de correspondance.</returns>
        public async Task<IEnumerable<byte[]?>> GetImageBonsai(int idUser)
        {
            IEnumerable<byte[]?> imageData = await _connection.QueryAsync<byte[]?>("SELECT Picture FROM[PictureBonsai] WHERE Id = @idParam", new { idParam = idUser });

            return imageData;
        }


    }
}
