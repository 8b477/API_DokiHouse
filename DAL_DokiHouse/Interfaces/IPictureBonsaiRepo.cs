using Entities_DokiHouse.Entities;

namespace DAL_DokiHouse.Interfaces
{
    public interface IPictureBonsaiRepo
    {

        /// <summary>
        /// Ajoute une image de bonsaï à la table [PictureBonsai] dans la base de données.
        /// </summary>
        /// <param name="file">Fichier image à ajouter.</param>
        /// <returns>L'identifiant généré de l'image ajoutée.</returns>
        Task<bool> AddPictureBonsai(PictureBonsai picture);
    }
}
