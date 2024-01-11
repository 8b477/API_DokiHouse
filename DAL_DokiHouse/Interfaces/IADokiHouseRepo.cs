
using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Repository;

namespace DAL_DokiHouse.Interfaces
{
    public interface IADokiHouseRepo
    {

        /// <summary>
        /// Récupère les users en base de donnée et toute ses relations
        /// </summary>
        /// <returns>Retourne la liste des users + leur relations</returns>
        Task<IEnumerable<FullJoinDTO>?> Infos(CancellationToken cancellationToken);


        /// <summary>
        /// Récupère les users en base de donnée et toute ses relations sur base de paramètre de pagination
        /// </summary>
        /// <returns>Retourne la liste des users + leur relations</returns>
        Task<IEnumerable<FullJoinDTO>?> InfosPaginated(int startIndex, int pageSize, CancellationToken cancellationToken);


        Task<PostJoinDTO?> GetPostWithComments(int userId);
        Task<UserTest?> GetInfosUserWithOwnBonsaisAndDetails(int startIndex, int pageSize, int userId);
        Task<UserTest2?> GetUserInfosWithOwnPostsAndComments(int userId);
    }
}
