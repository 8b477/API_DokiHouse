

using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Repository;

namespace BLL_DokiHouse.Interfaces
{
    public interface IADokiHouseBLLService
    {

        /// <summary>
        /// Récupère les users en base de donnée et toute ses relations
        /// </summary>
        /// <returns>Retourne la liste des users + leur relations</returns>
        Task<IEnumerable<FullJoinDTO>?> GetInfos(CancellationToken cancellationToken);


        /// <summary>
        /// Récupère les users en base de donnée et toute ses relations sur base de paramètre de pagination
        /// </summary>
        /// <returns>Retourne la liste des users + leur relations</returns>
        Task<IEnumerable<FullJoinDTO>?> GetInfosPaginated(int startIndex, int pageSize, CancellationToken cancellationToken);


        Task<PostJoinDTO?> GetPostWithComments(int userId);
        Task<UserTest?> GetInfosUserWithOwnBonsaisAndDetails(int startIndex, int pageSize, int userId);
        Task<UserTest2?> GetUserInfosWithOwnPostsAndComments(int userId);
    }
}
