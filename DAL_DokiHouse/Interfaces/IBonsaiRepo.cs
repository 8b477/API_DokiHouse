using DAL_DokiHouse.DTO;
using Entities_DokiHouse.Entities;


namespace DAL_DokiHouse.Interfaces
{
    public interface IBonsaiRepo : IRepo<Bonsai, BonsaiDTO, int, string>
    {
        /// <summary>
        /// Insert un Utilisateur dans la base de donnée.
        /// </summary>
        /// <param name="model">model à inséré en base de donnée</param>
        /// <returns></returns>
        Task<bool> Create(BonsaiDTO model);


        /// <summary>
        /// Met à jour les informations d'un bonsaï dans la base de données.
        /// </summary>
        /// <param name="bonsai">Les nouvelles informations du bonsaï.</param>
        /// <returns>True si la mise à jour a réussi, sinon False.</returns>
        Task<bool> Update(BonsaiDTO bonsai);

        /// <summary>
        /// Récupère la liste des bonsai associé à l'identifiant d'un Utilisateur
        /// </summary>
        /// <param name="idUser">L'identifiant sur le quelle la recherche se base</param>
        /// <returns>Retourne une liste de bonsai, si pas de bonsai associé retrouver retourne null</returns>
        Task<IEnumerable<BonsaiDTO>?> GetOwnBonsai(int idUser);
    }
}
