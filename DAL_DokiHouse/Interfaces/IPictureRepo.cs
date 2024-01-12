using DAL_DokiHouse.DTO;

namespace DAL_DokiHouse.Interfaces
{
    public interface IPictureRepo
    {

        /// <summary>
        /// Ajoute une image de bonsaï à la table [PictureBonsai] dans la base de données.
        /// </summary>
        /// <param name="file">Fichier image à ajouter.</param>
        /// <returns>L'identifiant généré de l'image ajoutée.</returns>
        Task<bool> AddPictureBonsai(PictureBonsaiDTO picture);
    }
}

/*
 
         /// <summary>
        /// Récupère l'image de profil associée à l'identifiant spécifié depuis la table [PictureProfil].
        /// </summary>
        /// <param name="idPicture">Identifiant de l'image à récupérer.</param>
        /// <returns>Les données de l'image de profil ou null si l'image n'est pas trouvée.</returns>
        Task<byte[]?> GetImageProfil(int idPicture);


        /// <summary>
        /// Récupère les images de bonsaï associées à l'utilisateur spécifié depuis la table [PictureBonsai].
        /// </summary>
        /// <param name="idUser">Identifiant de l'utilisateur dont les images de bonsaï doivent être récupérées.</param>
        /// <returns>Une collection des données d'images de bonsaï associées à l'utilisateur ou null si pas de correspondance.</returns>
        Task<IEnumerable<byte[]?>> GetImageBonsai(int idUser);

        /// <summary>
        /// Ajoute une image de profil à la table [PictureProfil] dans la base de données.
        /// </summary>
        /// <param name="file">Fichier image à ajouter.</param>
        /// <returns>L'identifiant généré de l'image ajoutée.</returns>
        Task<int> AddPictureProfil(IFormFile file);


*/