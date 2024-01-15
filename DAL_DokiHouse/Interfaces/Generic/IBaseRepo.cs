using Entities_DokiHouse.Interfaces;

namespace DAL_DokiHouse.Interfaces.Generic
{
    public interface IBaseRepo<E, U, S>
        where E : class, IEntity<U>, new()
        where U : struct
        where S : class
    {
        /// <summary>
        /// Récupère en base de données toute les infos relative à l'entité 'E'
        /// </summary>
        /// <returns>Retourne une liste d'Entité correspondant à 'E'</returns>
        Task<IEnumerable<E>> Get();

        /// <summary>
        /// Récupère en base de données toute les infos relative à l'entité de 'E' sur base d'un identifiant
        /// </summary>
        /// <param name="name">Paramètre de type STRING à rechercher.</param>
        /// <param name="stringIdentifiant">Paramètre de type STRING qui représente le nom de la colonne de la table sur la quelle faire la recherche</param>
        /// <returns></returns>
        Task<IEnumerable<E>?> GetBy(S name, S stringIdentifiant);

        /// <summary>
        /// Recherche en base de donnée les infos de l'entité 'E' sur base d'un identifiant de type INT
        /// </summary>
        /// <param name="id">identifiant de type INT</param>
        /// <returns>Retourne un entité correspondant à 'E' via son identifiant de type INT</returns>
        Task<E?> GetBy(U id);

        /// <summary>
        /// Supprime une entité de type 'E' en base de données
        /// </summary>
        /// <param name="id">identifiant de type INT</param>
        /// <returns>Retourne TRUE si l'entité à correctement été supprimer si non retourne FALSE</returns>
        Task<bool> Delete(U id);
    }
}