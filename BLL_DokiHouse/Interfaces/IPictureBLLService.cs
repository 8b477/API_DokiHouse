using BLL_DokiHouse.Models.FilePicture;

namespace BLL_DokiHouse.Interfaces
{
    public interface IPictureBLLService
    {
        /// <summary>
        /// Ajoute une image de Bonsai pour un utilisateur et met à jour la table User avec l'identifiant de l'image.
        /// </summary>
        /// <param name="filePicture">Fichier image à associer au Bonsai.</param>
        /// <param name="idBonsai">Identifiant du Bonsai à associé à l'image.</param>
        /// <returns>Identifiant de l'image du bonsai ajoutée.</returns>
        Task<bool> AddPictureBonsai(FilePictureModel filePicture , int idBonsai, string domain, string userId, string userName);

        /// <summary>
        /// Obtient le type MIME à partir de l'extension de fichier spécifiée.
        /// </summary>
        /// <param name="fileExtension">L'extension de fichier pour laquelle obtenir le type MIME.</param>
        /// <returns>Retourne le type MIME correspondant à l'extension de fichier spécifiée.</returns>
        string GetMimeTypeFromExtension(string fileExtension);
    }
}
