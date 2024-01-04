
using DAL_DokiHouse.DTO;

namespace DAL_DokiHouse.Interfaces
{
    public interface IADokiHouseRepo
    {

        /// <summary>
        /// Récupère les users en base de donnée et toute ses relations
        /// </summary>
        /// <returns>Retourne la liste des users + leur relations</returns>
        Task<IEnumerable<EveryDTO>?> Infos(CancellationToken cancellationToken);


        /// <summary>
        /// Récupère les users en base de donnée et toute ses relations sur base de paramètre de pagination
        /// </summary>
        /// <returns>Retourne la liste des users + leur relations</returns>
        Task<IEnumerable<EveryDTO>?> InfosPaginated(int startIndex, int pageSize, CancellationToken cancellationToken);

    }
}
