using BLL_DokiHouse.Models;
using DAL_DokiHouse.DTO;
using Entities_DokiHouse.Entities;


namespace BLL_DokiHouse.Interfaces
{
    public interface IUserBLLService
    {
        /// <summary>
        /// Créer un nouveau utilisateur en base de donnée
        /// </summary>
        /// <param name="model">attend un : 'UserCreateDTO'</param>
        /// <returns>Retoune 'true' si réussi ou si non 'false'</returns>
        Task<bool> Create(UserBLL model);

        /// <summary>
        /// Récupère les user en base de donnée
        /// </summary>
        /// <returns>Retourne la liste des user</returns>
        Task<IEnumerable<UserDisplayDTO>> Get();

        /// <summary>
        /// Récupère un User sur base d'un identifiant
        /// </summary>
        /// <param name="id">identifiant de type 'string'</param>
        /// <returns>Retourne le User qui correspond a la recherche ou si non retourne null</returns>
        Task<IEnumerable<UserDisplayDTO>?> GetByName(string name);


        /// <summary>
        /// Récupère un User sur base d'un identifiant
        /// </summary>
        /// <param name="id">identifiant de type 'int'</param>
        /// <returns>Retourne le User qui correspond a la recherche ou si non retourne null</returns>
        Task<UserDisplayDTO?> GetByID(int id);


        /// <summary>
        /// Met à jour un user
        /// </summary>
        /// <param name="id">Identifiant de type 'int'</param>
        /// <param name="model">model de création attendu : 'UserCreateDTO'</param>
        /// <returns>Retourne le user modifié si réussi, si non retourne null</returns>
        Task<bool> Update(int id, UserBLL model);


        /// <summary>
        /// Met à jour l'ID de l'image de profil pour un utilisateur spécifié.
        /// </summary>
        /// <param name="idPicture">L'ID de l'image de profil à associer à l'utilisateur.</param>
        /// <param name="idUser">L'ID de l'utilisateur dont l'image de profil doit être mise à jour.</param>
        /// <returns>Une tâche représentant l'opération de mise à jour.</returns>
        Task<bool> UpdateProfilPicture(int idPicture, int idUser);


        /// <summary>
        /// Supprime un élément sur base d'un identifiant
        /// </summary>
        /// <param name="id">Un identifiant de type : int</param>
        /// <returns>Retourne true si l'item à bien été supprimer de la base de donnée dans le cas contraire retourne false</returns>
        Task<bool> Delete(int id);


        /// <summary>
        /// Vérifie si un User est présent en base de donnée sur base de mot de passe et email
        /// </summary>
        /// <param name="email">Attendue emai de type : string</param>
        /// <param name="passwd">Attendue mot de passe de type : string</param>
        /// <returns></returns>
        Task<User?> Login(string email, string passwd);

    }
}