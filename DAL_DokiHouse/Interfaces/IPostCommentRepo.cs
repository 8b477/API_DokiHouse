using DAL_DokiHouse.DTO.Post;

namespace DAL_DokiHouse.Interfaces
{
    public interface IPostCommentRepo
    {
        /// <summary>
        /// Récupère tout les post et les commentaires en base de données sur base d'un identifiant utilisateur.
        /// </summary>
        /// <param name="idUser">Un identifiant utilisateur de type : int</param>
        /// <returns>Retourne une liste de Post et de commentaire basé sur l'identifiant d'un utilisateur</returns>
        Task<IEnumerable<PostAndCommentDTO>?> GetPostsAndComments(int idUser);


        /// <summary>
        /// Récupère tout les post et les commentaires en base de données sur base d'un identifiant utilisateur.
        /// </summary>
        /// <param name="startIndex">Index de départ de type INT pour la récupération des données</param>
        /// <param name="pageSize">Un nombre d'item de type INT qui représente les données récupérer par page</param>
        /// <returns>Retourne une liste de Post et de commentaire sur base d'une pagination</returns>
        Task<IEnumerable<PostAndCommentDTO>?> GetPostsAndComments(int startIndex, int pageSize);
    }
}
