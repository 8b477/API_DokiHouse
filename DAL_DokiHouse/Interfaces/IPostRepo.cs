using DAL_DokiHouse.DTO;
using Entities_DokiHouse.Entities;


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

        /// <summary>
        /// Récupère la liste des commentaires associé à l'identifiant d'un Utilisateur
        /// </summary>
        /// <param name="idUser">L'identifiant sur le quelle la recherche se base</param>
        /// <returns>Retourne une liste de commentaires, si pas de commentaire associé retrouver retourne null</returns>
        Task<IEnumerable<PostDTO>?> GetOwnPosts(int idUser);
    }
}
