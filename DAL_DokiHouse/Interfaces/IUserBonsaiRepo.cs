using DAL_DokiHouse.DTO.User;

namespace DAL_DokiHouse.Interfaces
{
    public interface IUserBonsaiRepo
    {
        /// <summary>
        /// Récupère toutes les infos des utilisateurs, permet aussi de paginé les datas.
        /// </summary>
        /// <param name="startIndex">Paramètre de type : 'int', représente l'index de départ, ne peut pas être négatif</param>
        /// <param name="pageSize">Paramètre de type : 'int', représente le nombre d'éléments retourner</param>
        /// <returns>Retourne une liste d'utilisateur avec leur infos</returns>
        Task<IEnumerable<UserAndBonsaiDetails?>> GetInfos(int startIndex, int pageSize);


        /// <summary>
        /// Récupère toutes les infos d'un utilisateurs, sur base d'un identifiant.
        /// </summary>
        /// <param name="idUser">Paramètre de type : 'int', représente l'identifiant d'un utilisateur</param>
        /// <returns>Retourne un utilisateur avec ses infos</returns>
        Task<UserAndBonsaiDetails?> GetInfosById(int idUser);
    }
}