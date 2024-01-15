using API_DokiHouse.Models;
using Entities_DokiHouse.Entities;

namespace BLL_DokiHouse.Interfaces
{
    public interface ICommentsBLLService
    {

        /// <summary>
        /// Crée un nouveau commentaire.
        /// </summary>
        /// <param name="comment">Les données du commentaire à créer.</param>
        /// <returns>Retourne vrai si la création est réussie, sinon faux.</returns>
        Task<bool> CreateComment(CommentModel comment, int idPost, int idToken);


        /// <summary>
        /// Récupère la liste complète des commentaires.
        /// </summary>
        /// <returns>Retourne la liste des commentaires.</returns>
        Task<IEnumerable<Comments>> GetComments();


        /// <summary>
        /// Récupère la liste complète des commentaires liée à l'utilisateur identifié.
        /// </summary>
        /// <param name="idUser">L'identifiant utilisateur de type : 'int'.</param>
        /// <returns>Retourne la liste des commentaires.</returns>
        Task<IEnumerable<Comments>?> GetOwnComments(int idUser);


        /// <summary>
        /// Récupère un commentaire en utilisant son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du commentaire à récupérer.</param>
        /// <returns>Retourne le commentaire correspondant à l'identifiant.</returns>
        Task<Comments?> GetCommentById(int id);


        /// <summary>
        /// Récupère la liste des commentaires par nom.
        /// </summary>
        /// <param name="name">Le nom à utiliser pour la recherche des commentaires.</param>
        /// <returns>Retourne la liste des commentaires correspondant au nom.</returns>
        Task<IEnumerable<Comments>?> GetCommentsByName(string name, string stringIdentifiant);


        /// <summary>
        /// Met à jour les informations d'un commentaire.
        /// </summary>
        /// <param name="comment">Les données mises à jour du commentaire.</param>
        /// <returns>Retourne vrai si la mise à jour est réussie, sinon faux.</returns>
        Task<bool> UpdateComment(CommentModel comment, int id);


        /// <summary>
        /// Supprime un commentaire en utilisant son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du commentaire à supprimer.</param>
        /// <returns>Retourne vrai si la suppression est réussie, sinon faux.</returns>
        Task<bool> DeleteComment(int id);
    }
}