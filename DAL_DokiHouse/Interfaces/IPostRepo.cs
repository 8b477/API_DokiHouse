

using DAL_DokiHouse.DTO;

using Dapper;

using Entities_DokiHouse.Entities;

using System.Data.Common;

namespace DAL_DokiHouse.Interfaces
{
    public interface IPostRepo : IRepo<Post, PostDTO, int, string>
    {
        /// <summary>
        /// Créé un nouveau post sur base d'un modèle
        /// </summary>
        /// <param name="post">modèle sur le quelle se base la création</param>
        /// <returns>Retourne True si la création à réussi si non retourne False</returns>
        Task<bool> Create(PostDTO post);

        /// <summary>
        /// Met à jour un post sur base d'un modèle qui se trouve en base de donnée
        /// </summary>
        /// <param name="post">modèle sur le quelle se base la mise à jour</param>
        /// <returns>Retourne true si la mise à jour à réussi si non retourne False</returns>
        Task<bool> Update(PostDTO post);
    }
}
