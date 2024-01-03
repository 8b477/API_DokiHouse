using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;
using Entities_DokiHouse.Entities;


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
        /// Met à jour les informations d'un utilisateur existant avec les données fournies dans le modèle.
        /// </summary>
        /// <param name="model">Le modèle UserDTO contenant les nouvelles informations de l'utilisateur.</param>
        /// <returns>Retourne true si la mise à jour est réussie, sinon retourne false.</returns>
        Task<bool> Update(UserDTO model);


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
        /// Récupère les users en base de donnée et toute ses relations
        /// </summary>
        /// <returns>Retourne la liste des users + leur relations</returns>
        Task<IEnumerable<EveryDTO>?> Infos();
    }
}
