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
        Task<bool> Create(Post post);

        /// <summary>
        /// Met à jour un post en base de donnée
        /// </summary>
        /// <param name="post">modèle sur le quelle se base la mise à jour</param>
        /// <returns>Retourne true si la mise à jour à réussi si non retourne False</returns>
        Task<bool> Update(Post post);


        /// <summary>
        /// Récupère tout les post et les commentaires en base de données sur base d'un identifiant utilisateur.
        /// </summary>
        /// <param name="postId">Un identifiant utilisateur de type : int</param>
        /// <returns></returns>
        Task<PostAndCommentDTO>? GetPostsAndComments(int idPost);


        /// <summary>
        /// Récupère tout les post disponible en base de donnée sur base d'un identifiant utilisateur.
        /// </summary>
        /// <param name="idUser">Un identifiant utilisateur de type : int</param>
        /// <returns></returns>
        Task<IEnumerable<Post>?> GetPosts(int idUser);
    }
}
