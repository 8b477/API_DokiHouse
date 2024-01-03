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
        /// Vas chercher en base de donnée tout les bonsai associé à un Utilsateur
        /// </summary>
        /// <param name="idUser">Identifiant de type : 'int'</param>
        /// <returns>Retourne une liste de bonsai, ou une liste vide si pas de bonsai trouver</returns>
        Task<IEnumerable<BonsaiDTO>> Get(int idUser);
    }
}
