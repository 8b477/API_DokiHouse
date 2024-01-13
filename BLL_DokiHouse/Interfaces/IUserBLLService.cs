using BLL_DokiHouse.Models;
using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Repository;

using static DAL_DokiHouse.UserRepo;


namespace BLL_DokiHouse.Interfaces
{
    public interface IUserBLLService
    {

        /// <summary>
        /// Créer un nouveau utilisateur en base de donnée
        /// </summary>
        /// <param name="model">attend un : 'UserCreateDTO'</param>
        /// <returns>Retoune 'true' si réussi ou si non 'false'</returns>
        Task<bool> CreateUser(UserBLL model);


        /// <summary>
        /// Récupère un User sur base d'un identifiant
        /// </summary>
        /// <param name="id">identifiant de type 'string'</param>
        /// <returns>Retourne le User qui correspond a la recherche ou si non retourne null</returns>
        Task<IEnumerable<UserDTO?>> GetUsersByName(string name, string stringIdentifiant);


        /// <summary>
        /// Récupère un User sur base d'un identifiant
        /// </summary>
        /// <param name="id">identifiant de type 'int'</param>
        /// <returns>Retourne le User qui correspond a la recherche ou si non retourne null</returns>
        Task<UserDTO?> GetUserByID(int id);


        /// <summary>
        /// Met à jour le nom d'un utilisateur existant avec les données fournies dans le modèle.
        /// </summary>
        /// <param name="model">Le modèle UserDTO contenant les nouvelles informations de l'utilisateur.</param>
        /// <returns>Retourne true si la mise à jour est réussie, sinon retourne false.</returns>
        Task<bool> UpdateUser(int id, UserUpdateBLL model);


        /// <summary>
        /// Met à jour le nom d'un utilisateur existant avec les données fournies dans le modèle.
        /// </summary>
        /// <param name="model">Le modèle UserDTO contenant les nouvelles informations de l'utilisateur.</param>
        /// <returns>Retourne true si la mise à jour est réussie, sinon retourne false.</returns>
        Task<bool> UpdateUserName(int id, UserUpdateNameBLL model);


        /// <summary>
        /// Met à jour le pass d'un utilisateur existant avec les données fournies dans le modèle.
        /// </summary>
        /// <param name="model">Le modèle UserDTO contenant les nouvelles informations de l'utilisateur.</param>
        /// <returns>Retourne true si la mise à jour est réussie, sinon retourne false.</returns>
        Task<bool> UpdateUserPass(int id, UserUpdatePassBLL model);


        /// <summary>
        /// Met à jour le mail d'un utilisateur existant avec les données fournies dans le modèle.
        /// </summary>
        /// <param name="model">Le modèle UserDTO contenant les nouvelles informations de l'utilisateur.</param>
        /// <returns>Retourne true si la mise à jour est réussie, sinon retourne false.</returns>
        Task<bool> UpdateUserEmail(int id, UserUpdateMailBLL model);


        /// <summary>
        /// Supprime un élément sur base d'un identifiant
        /// </summary>
        /// <param name="id">Un identifiant de type : int</param>
        /// <returns>Retourne true si l'item à bien été supprimer de la base de donnée dans le cas contraire retourne false</returns>
        Task<bool> DeleteUser(int id);


        /// <summary>
        /// Vérifie si un User est présent en base de donnée sur base de mot de passe et email
        /// </summary>
        /// <param name="email">Attendue emai de type : string</param>
        /// <param name="passwd">Attendue mot de passe de type : string</param>
        /// <returns>Retourne un objet 'UserDTO' si le User est validé si non 'null'</returns>
        Task<UserDTO?> Login(string email, string passwd);


        /// <summary>
        /// Met à jour l'ID de l'image de profil pour un utilisateur spécifié.
        /// </summary>
        /// <param name="idPicture">L'ID de l'image de profil à associer à l'utilisateur.</param>
        /// <param name="idUser">L'ID de l'utilisateur dont l'image de profil doit être mise à jour.</param>
        /// <returns>Une tâche représentant l'opération de mise à jour.</returns>
        Task<bool> UpdateProfilPicture(int idPicture, int idUser);


        /// <summary>
        /// Récupère toutes les infos des utilisateurs, permet aussi de paginé les datas.
        /// </summary>
        /// <param name="startIndex">Paramètre de type : 'int', représente l'index de départ, ne peut pas être négatif</param>
        /// <param name="pageSize">Paramètre de type : 'int', représente le nombre d'éléments retourner</param>
        /// <returns>Retourne une liste d'utilisateur avec leur infos</returns>
        Task<IEnumerable<UserTest?>> GetInfos(int startIndex, int pageSize);


        /// <summary>
        /// Récupère toutes les infos des utilisateurs, permet aussi de paginé les datas.
        /// </summary>
        /// <param name="idUser">Paramètre de type : 'int', représente l'identifiant de l'utilisateur</param>
        /// <param name="startIndex">Paramètre de type : 'int', représente l'index de départ, ne peut pas être négatif</param>
        /// <param name="pageSize">Paramètre de type : 'int', représente le nombre d'éléments retourner</param>
        /// <returns>Retourne une liste d'utilisateur avec leur infos</returns>
        Task<UserTest?> GetInfosById(int idUser);


        /// <summary>
        /// Récupère la liste des utilisateurs en base de donnée.
        /// </summary>
        /// <returns>Retourne une liste d'utilisateurs</returns>
        Task<IEnumerable<UserAndPictureDTO>> Get();
    }
}