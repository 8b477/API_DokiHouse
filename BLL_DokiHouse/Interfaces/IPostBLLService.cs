using API_DokiHouse.Models;
using DAL_DokiHouse.DTO.Post;

using Entities_DokiHouse.Entities;


namespace BLL_DokiHouse.Interfaces
{
    public interface IPostBLLService
    {
        /// <summary>
        /// Crée un nouveau post.
        /// </summary>
        /// <param name="post">Les données du post à créer.</param>
        /// <returns>Retourne vrai si la création est réussie, sinon faux.</returns>
        Task<bool> CreatePost(int idUser, PostModel post);


        /// <summary>
        /// Récupère la liste complète des posts.
        /// </summary>
        /// <returns>Retourne la liste des posts.</returns>
        Task<IEnumerable<Post>?> GetPosts();


        /// <summary>
        /// Récupère un post en utilisant son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du post à récupérer.</param>
        /// <returns>Retourne le post correspondant à l'identifiant.</returns>
        Task<Post?> GetPostById(int id);


        /// <summary>
        /// Récupère la liste des posts par nom.
        /// </summary>
        /// <param name="name">Le nom à utiliser pour la recherche des posts.</param>
        /// <returns>Retourne la liste des posts correspondant au nom.</returns>
        Task<IEnumerable<Post>?> GetPostsByName(string name, string stringIdentifiant);


        /// <summary>
        /// Met à jour les informations d'un post.
        /// </summary>
        /// <param name="post">Les données mises à jour du post.</param>
        /// <returns>Retourne vrai si la mise à jour est réussie, sinon faux.</returns>
        Task<bool> UpdatePost(int idPost,int idToken, PostModel post);


        /// <summary>
        /// Supprime un post en utilisant son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du post à supprimer.</param>
        /// <returns>Retourne vrai si la suppression est réussie, sinon faux.</returns>
        Task<bool> DeletePost(int id);


        /// <summary>
        /// Vas chercher en base de données tout les post lié à un utilisateur préalablement Log.
        /// </summary>
        /// <param name="idUser">Identifiant de l'utilisateur de type INT sur le quelle se base la recherche</param>
        /// <returns>Retourne une liste de post lié à l'identifiant de l'utilisateur, peux retourner NULL si pas de correspondance trouver en DB</returns>
        Task<IEnumerable<Post>?> OwnPost(int idUser);

    }
}