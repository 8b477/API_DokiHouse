using DAL_DokiHouse.Interfaces.Generic;
using Entities_DokiHouse.Entities;

namespace DAL_DokiHouse.Interfaces
{
    public interface IPictureBonsaiRepo : IBaseRepo<PictureBonsai, int, string>
    {

        /// <summary>
        /// Ajoute une image de bonsaï à la table [PictureBonsai] dans la base de données.
        /// </summary>
        /// <param name="file">Fichier image à ajouter.</param>
        /// <returns>L'identifiant généré de l'image ajoutée.</returns>
        Task<bool> AddPictureBonsai(int idBonsai, PictureBonsai picture);
    }
}
