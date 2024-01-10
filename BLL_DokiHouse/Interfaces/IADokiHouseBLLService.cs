

using DAL_DokiHouse.DTO;

namespace BLL_DokiHouse.Interfaces
{
    public interface IADokiHouseBLLService
    {

        /// <summary>
        /// Récupère les users en base de donnée et toute ses relations
        /// </summary>
        /// <returns>Retourne la liste des users + leur relations</returns>
        Task<IEnumerable<EveryDTO>?> GetInfos(CancellationToken cancellationToken);


        /// <summary>
        /// Récupère les users en base de donnée et toute ses relations sur base de paramètre de pagination
        /// </summary>
        /// <returns>Retourne la liste des users + leur relations</returns>
        Task<IEnumerable<EveryDTO>?> GetInfosPaginated(int startIndex, int pageSize, CancellationToken cancellationToken);


        Task<IEnumerable<object>?> InfosTest(CancellationToken cancellationToken);
    }
}
