using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;
using DAL_DokiHouse.Repository;

using Entities_DokiHouse.Entities;

using static DAL_DokiHouse.UserRepo;


namespace DAL_DokiHouse
{
    public interface IUserRepo : IRepo<User, UserDTO, int, string>
    {

        /// <summary>
        /// Crée un nouvel utilisateur en ajoutant les informations fournies dans le modèle.
        /// </summary>
        /// <param name="model">Le modèle UserDTO contenant les informations de l'utilisateur à créer.</param>
        /// <returns>Retourne true si la création est réussie, sinon retourne false.</returns>
        Task<bool> Create(UserDTO model);


        /// <summary>
        /// Met à jour le nom d'un utilisateur existant avec les données fournies dans le modèle.
        /// </summary>
        /// <param name="model">Le modèle UserDTO contenant les nouvelles informations de l'utilisateur.</param>
        /// <returns>Retourne true si la mise à jour est réussie, sinon retourne false.</returns>
        Task<bool> Update(UserDTO model);


        /// <summary>
        /// Met à jour le nom d'un utilisateur existant avec les données fournies dans le modèle.
        /// </summary>
        /// <param name="model">Le modèle UserDTO contenant les nouvelles informations de l'utilisateur.</param>
        /// <returns>Retourne true si la mise à jour est réussie, sinon retourne false.</returns>
        Task<bool> UpdateName(UserUpNameDTO model);


        /// <summary>
        /// Met à jour le pass d'un utilisateur existant avec les données fournies dans le modèle.
        /// </summary>
        /// <param name="model">Le modèle UserDTO contenant les nouvelles informations de l'utilisateur.</param>
        /// <returns>Retourne true si la mise à jour est réussie, sinon retourne false.</returns>
        Task<bool> UpdatePass(UserUpPassDTO model);


        /// <summary>
        /// Met à jour le mail d'un utilisateur existant avec les données fournies dans le modèle.
        /// </summary>
        /// <param name="model">Le modèle UserDTO contenant les nouvelles informations de l'utilisateur.</param>
        /// <returns>Retourne true si la mise à jour est réussie, sinon retourne false.</returns>
        Task<bool> UpdateEmail(UserUpMailDTO model);


        /// <summary>
        /// Authentifie un utilisateur en vérifiant l'e-mail et le mot de passe.
        /// </summary>
        /// <param name="email">L'e-mail de l'utilisateur à authentifier.</param>
        /// <param name="motDePasse">Le mot de passe fourni par l'utilisateur.</param>
        /// <returns>Retourne l'utilisateur authentifié s'il existe, sinon retourne null.</returns>
        Task<UserDTO?> Logger(string email, string motDePasse);


        /// <summary>
        /// Met à jour la colonne IdPictureProfil de la table [User] avec la nouvelle valeur spécifiée.
        /// </summary>
        /// <param name="idUser">Identifiant de l'utilisateur à mettre à jour.</param>
        /// <param name="idPicture">Nouvelle valeur à assigner à la colonne IdPictureProfil.</param>
        /// <returns>Une tâche représentant l'opération asynchrone.</returns>
        Task<bool> UpdateProfilPicture(int idUser, int idPicture);


        /// <summary>
        /// Récupère toutes les infos des utilisateurs, permet aussi de paginé les datas.
        /// </summary>
        /// <param name="startIndex">Paramètre de type : 'int', représente l'index de départ, ne peut pas être négatif</param>
        /// <param name="pageSize">Paramètre de type : 'int', représente le nombre d'éléments retourner</param>
        /// <returns>Retourne une liste d'utilisateur avec leur infos</returns>
        Task<IEnumerable<UserDetailsBonsaiDTO?>> GetInfos(int startIndex, int pageSize);


        /// <summary>
        /// Récupère toutes les infos d'un utilisateurs, sur base d'un identifiant.
        /// </summary>
        /// <param name="idUser">Paramètre de type : 'int', représente l'identifiant d'un utilisateur</param>
        /// <returns>Retourne un utilisateur avec ses infos</returns>
        Task<UserDetailsBonsaiDTO?> GetInfosById(int idUser);


        /// <summary>
        /// Récupère la liste des utilisateurs en base de donnée.
        /// </summary>
        /// <returns>Retourne une liste d'utilisateurs</returns>
        new Task<IEnumerable<UserAndPictureDTO>> Get();
    }
}
