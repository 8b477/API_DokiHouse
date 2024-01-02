using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;
using Entities_DokiHouse.Entities;


namespace DAL_DokiHouse
{
    public interface IUserRepo : IRepo<User, UserDTO, UserCreateDTO, UserDisplayDTO, int, string>
    {

        /// <summary>
        /// Authentifie un utilisateur en vérifiant l'e-mail et le mot de passe.
        /// </summary>
        /// <param name="email">L'e-mail de l'utilisateur à authentifier.</param>
        /// <param name="motDePasse">Le mot de passe fourni par l'utilisateur.</param>
        /// <returns>Retourne l'utilisateur authentifié s'il existe, sinon retourne null.</returns>
        Task<User?> Logger(string email, string motDePasse);


        /// <summary>
        /// Met à jour la colonne IdPictureProfil de la table [User] avec la nouvelle valeur spécifiée.
        /// </summary>
        /// <param name="idUser">Identifiant de l'utilisateur à mettre à jour.</param>
        /// <param name="idPicture">Nouvelle valeur à assigner à la colonne IdPictureProfil.</param>
        /// <returns>Une tâche représentant l'opération asynchrone.</returns>
        Task<bool> UpdateProfilPicture(int idUser, int idPicture);
    }
}
