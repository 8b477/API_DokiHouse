using DAL_DokiHouse.DTO.User;
using DAL_DokiHouse.Interfaces.Generic;
using Entities_DokiHouse.Entities;


namespace DAL_DokiHouse
{
    public interface IUserRepo : IBaseRepo<User, int, string>
    {

        /// <summary>
        /// Crée un nouvel utilisateur en ajoutant les informations fournies dans le modèle.
        /// </summary>
        /// <param name="model">Le modèle UserDTO contenant les informations de l'utilisateur à créer.</param>
        /// <returns>Retourne true si la création est réussie, sinon retourne false.</returns>
        Task<int> Create(User model);


        /// <summary>
        /// Met à jour le nom d'un utilisateur existant avec les données fournies dans le modèle.
        /// </summary>
        /// <param name="model">Le modèle UserDTO contenant les nouvelles informations de l'utilisateur.</param>
        /// <param name="id">L'identifiant utilisateur de type INT.</param>
        /// <returns>Retourne true si la mise à jour est réussie, sinon retourne false.</returns>
        Task<bool> Update(int id, User model);


        /// <summary>
        /// Met à jour le nom d'un utilisateur existant avec les données fournies dans le modèle.
        /// </summary>
        /// <param name="model">Le modèle UserDTO contenant les nouvelles informations de l'utilisateur.</param>
        /// <param name="idUser">L'identifiant utilisateur de type INT.</param>
        /// <returns>Retourne true si la mise à jour est réussie, sinon retourne false.</returns>
        Task<bool> UpdateName(int idUser, User model);


        /// <summary>
        /// Met à jour le pass d'un utilisateur existant avec les données fournies dans le modèle.
        /// </summary>
        /// <param name="model">Le modèle UserDTO contenant les nouvelles informations de l'utilisateur.</param>
        /// <param name="idUser">L'identifiant utilisateur de type INT.</param>
        /// <returns>Retourne true si la mise à jour est réussie, sinon retourne false.</returns>
        Task<bool> UpdatePass(int idUser,User model);


        /// <summary>
        /// Met à jour le mail d'un utilisateur existant avec les données fournies dans le modèle.
        /// </summary>
        /// <param name="model">Le modèle UserDTO contenant les nouvelles informations de l'utilisateur.</param>
        /// <param name="idUser">L'identifiant utilisateur de type INT.</param>
        /// <returns>Retourne true si la mise à jour est réussie, sinon retourne false.</returns>
        Task<bool> UpdateEmail(int idUser, User model);


        /// <summary>
        /// Authentifie un utilisateur en vérifiant l'e-mail et le mot de passe.
        /// </summary>
        /// <param name="email">L'e-mail de l'utilisateur à authentifier.</param>
        /// <param name="motDePasse">Le mot de passe fourni par l'utilisateur.</param>
        /// <returns>Retourne l'utilisateur authentifié s'il existe, sinon retourne null.</returns>
        Task<User?> Logger(string email, string motDePasse);



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
        /// Récupère le passwd stocker en base de données sur base d'un Id utilisateur.
        /// </summary>
        /// <param name="idUser">Paramètre : 'Int' à comparer</param>
        /// <returns>Retourne passwd : 'String' si correspondance, sinon retourne 'Null'</returns>
        Task<string?> CheckPasswd(int idUser);

        /// <summary>
        /// Compare le mail d'un utilisateur en base de donnée avec celui fournis en paramètre, l'utilisateur lui est identifié par son ID
        /// </summary>
        /// <param name="idUser">Identifiant de type 'int'</param>
        /// <param name="mail">Mail à comparé de type 'string'</param>
        /// <returns></returns>
        Task<bool> CheckMail(int idUser, string mail);


        /// <summary>
        /// Met à jour la colonne IdPictureProfil de la table [User] avec la nouvelle valeur spécifiée.
        /// </summary>
        /// <param name="idUser">Identifiant de l'utilisateur à mettre à jour.</param>
        /// <param name="idPicture">Nouvelle valeur à assigner à la colonne IdPictureProfil.</param>
        /// <returns>Une tâche représentant l'opération asynchrone.</returns>
        // Task<bool> UpdateProfilPicture(int idUser, int idPicture);
    }
}
