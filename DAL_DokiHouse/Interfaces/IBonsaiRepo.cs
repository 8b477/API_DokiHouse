using DAL_DokiHouse.Interfaces.Generic;

using Entities_DokiHouse.Entities;


namespace DAL_DokiHouse.Interfaces
{
    public interface IBonsaiRepo : IBaseRepo<Bonsai, int, string>
    {
        /// <summary>
        /// Insert un Utilisateur dans la base de donnée.
        /// </summary>
        /// <param name="model">model à inséré en base de donnée</param>
        /// <returns></returns>
        Task<bool> Create(Bonsai bonsai, int idUser);


        /// <summary>
        /// Met à jour les informations d'un bonsaï dans la base de données.
        /// </summary>
        /// <param name="bonsai">Les nouvelles informations du bonsaï.</param>
        /// <returns>True si la mise à jour a réussi, sinon False.</returns>
        Task<bool> Update(Bonsai bonsai, int idBonsai);

        /// <summary>
        /// Récupère la liste des bonsai associé à l'identifiant d'un Utilisateur
        /// </summary>
        /// <param name="idUser">L'identifiant sur le quelle la recherche se base</param>
        /// <returns>Retourne une liste de bonsai, si pas de bonsai associé retrouver retourne null</returns>
        Task<IEnumerable<Bonsai>?> GetOwnBonsai(int idUser);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<BonsaiPictureDTO>?> GetBonsaiAndPicture(int idUser);
    }
}
