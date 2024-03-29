﻿using BLL_DokiHouse.Models.User;
using BLL_DokiHouse.Models.User.View;

using DAL_DokiHouse.DTO.User;
using Entities_DokiHouse.Entities;


namespace BLL_DokiHouse.Interfaces
{
    public interface IUserBLLService
    {

        /// <summary>
        /// Créer un nouveau utilisateur en base de donnée
        /// </summary>
        /// <param name="model">attend un : 'UserCreateDTO'</param>
        /// <returns>Retourne 'true' si réussi ou si non 'false'</returns>
        Task<UserView?> CreateUser(UserCreateModel model);


        /// <summary>
        /// Récupère un User sur base d'un identifiant
        /// </summary>
        /// <param name="id">identifiant de type 'string'</param>
        /// <returns>Retourne le User qui correspond a la recherche ou si non retourne null</returns>
        Task<IEnumerable<User?>?> GetUsersByName(string name, string stringIdentifiant);


        /// <summary>
        /// Récupère un User sur base d'un identifiant
        /// </summary>
        /// <param name="id">identifiant de type 'int'</param>
        /// <returns>Retourne le User qui correspond a la recherche ou si non retourne null</returns>
        Task<UserView?> GetUserByID(int id);


        /// <summary>
        /// Met à jour le nom d'un utilisateur existant avec les données fournies dans le modèle.
        /// </summary>
        /// <param name="model">Le modèle UserDTO contenant les nouvelles informations de l'utilisateur.</param>
        /// <returns>Retourne true si la mise à jour est réussie, sinon retourne false.</returns>
        Task<bool> UpdateUser(int id, UserUpdateModel model);


        /// <summary>
        /// Met à jour le nom d'un utilisateur existant avec les données fournies dans le modèle.
        /// </summary>
        /// <param name="model">Le modèle UserDTO contenant les nouvelles informations de l'utilisateur.</param>
        /// <returns>Retourne true si la mise à jour est réussie, sinon retourne false.</returns>
        Task<bool> UpdateUserName(int id, UserUpdateNameModel model);


        /// <summary>
        /// Met à jour le pass d'un utilisateur existant avec les données fournies dans le modèle.
        /// </summary>
        /// <param name="model">Le modèle UserDTO contenant les nouvelles informations de l'utilisateur.</param>
        /// <returns>Retourne true si la mise à jour est réussie, sinon retourne false.</returns>
        Task<bool> UpdateUserPass(int id, UserUpdatePasswdModel model);


        /// <summary>
        /// Met à jour le mail d'un utilisateur existant avec les données fournies dans le modèle.
        /// </summary>
        /// <param name="model">Le modèle UserDTO contenant les nouvelles informations de l'utilisateur.</param>
        /// <returns>Retourne true si la mise à jour est réussie, sinon retourne false.</returns>
        Task<bool> UpdateUserEmail(int id, UserUpdateEmailModel model);


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
        Task<User?> Login(string email, string passwd);


        /// <summary>
        /// Récupère la liste des utilisateurs en base de donnée.
        /// </summary>
        /// <returns>Retourne une liste d'utilisateurs</returns>
        Task<IEnumerable<UserAndPictureDTO>> GetUsers(int startIndex, int pageSize);


        /// <summary>
        /// Récupère l'utilisateurs en base de donnée sur base d'un identifiant de type INT.
        /// </summary>
        /// <param name="idUser">Identifiant de type INT</param>
        /// <returns>Retourne un utilisateur ou null si pas de correspondance</returns>
        Task<UserAndPictureDTO?> GetUser(int idUser);


        /// <summary>
        /// Compare le passwd entrée en paramètre avec celui stocker en base de données.
        /// </summary>
        /// <param name="idUser">Identifiant de l'utilisateur : 'Int' </param>
        /// <param name="passwd">Paramètre à comparer : 'String' </param>
        /// <returns>Retourne le passwd : 'String' correspondant, sinon retourne 'Null'</returns>
        Task<bool> CheckPasswd(int idUser, string passwd);


        /// <summary>
        /// Compare le mail entré en paramètre à celui associé à l'identité d'un utilisateur authentifié dans la base de données.
        /// </summary>
        /// <param name="idUser">Identifiant de type 'int';</param>
        /// <param name="mail">Mail à comparée de type 'string';</param>
        /// <returns></returns>
        Task<bool> CheckMail(int idUser, string mail);


        ///// <summary>
        ///// Met à jour l'ID de l'image de profil pour un utilisateur spécifié.
        ///// </summary>
        ///// <param name="idPicture">L'ID de l'image de profil à associer à l'utilisateur.</param>
        ///// <param name="idUser">L'ID de l'utilisateur dont l'image de profil doit être mise à jour.</param>
        ///// <returns>Une tâche représentant l'opération de mise à jour.</returns>
        //Task<bool> UpdateProfilPicture(int idPicture, int idUser);
    }
}