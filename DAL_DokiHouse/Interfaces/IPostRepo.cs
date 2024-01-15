using DAL_DokiHouse.DTO.Post;
using DAL_DokiHouse.Interfaces.Generic;
using Entities_DokiHouse.Entities;


namespace DAL_DokiHouse.Interfaces
{
    public interface IPostRepo : IBaseRepo<Post, int, string>
    {
        /// <summary>
        /// Créé un nouveau post sur base d'un modèle
        /// </summary>
        /// <param name="post">modèle sur le quelle se base la création</param>
        /// <returns>Retourne True si la création à réussi si non retourne False</returns>
        Task<bool> Create(int idUser, Post post);

        /// <summary>
        /// Met à jour un post en base de donnée
        /// </summary>
        /// <param name="post">modèle sur le quelle se base la mise à jour</param>
        /// <returns>Retourne true si la mise à jour à réussi si non retourne False</returns>
        Task<bool> Update(int idPost, Post post);


        /// <summary>
        /// Récupère tout les post et les commentaires en base de données sur base d'un identifiant utilisateur.
        /// </summary>
        /// <param name="idPost">Un identifiant utilisateur de type : int</param>
        /// <returns></returns>
        Task<IEnumerable<PostAndCommentDTO>>? GetPostsAndComments(int idUser);


    }
}
