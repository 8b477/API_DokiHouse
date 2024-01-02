using DAL_DokiHouse.DTO;
using Entities_DokiHouse.Entities;

using static DAL_DokiHouse.Repository.BonsaiRepo;

namespace DAL_DokiHouse.Interfaces
{
    public interface IBonsaiRepo : IRepo<Bonsai, BonsaiDTO, BonsaiCreateDTO, BonsaiDisplayDTO, int, string>
    {

        /// <summary>
        /// Met à jour les informations d'un bonsaï dans la base de données.
        /// </summary>
        /// <param name="bonsai">Les nouvelles informations du bonsaï.</param>
        /// <returns>True si la mise à jour a réussi, sinon False.</returns>
        Task<bool> UpdateBonsai(BonsaiDTO bonsai);


        /// <summary>
        /// Récupère tous les bonsaïs avec leurs informations associées depuis la base de données.
        /// </summary>
        /// <returns>Une liste de BonsaiAndChild contenant les informations des bonsaïs et de leurs enfants (Category, Style, Note).</returns>
        Task<IEnumerable<BonsaiAndChild>?> GetAllBonsai();


        /// <summary>
        /// Récupère tous les bonsaïs d'un utilisateur avec leurs informations associées depuis la base de données.
        /// </summary>
        /// <param name="idUser">L'ID de l'utilisateur.</param>
        /// <returns>Une liste de BonsaiAndChild contenant les informations des bonsaïs et de leurs enfants (Category, Style, Note).</returns>
        Task<IEnumerable<BonsaiAndChild>> GetAllBonsai(int idUser);



        Task<IEnumerable<UserEveryDTO>?> GetTest();
    }
}
