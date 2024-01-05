
using DAL_DokiHouse.DTO;

namespace DAL_DokiHouse.Interfaces
{
    public interface IStyleRepo
    {

        /// <summary>
        /// Crée un nouveau style à partir d'un objet DTO.
        /// </summary>
        /// <param name="style">Objet DTO représentant le style à créer.</param>
        /// <returns>Une tâche asynchrone qui indique si la création a réussi.</returns>
        Task<bool> Create(StyleDTO style);


        /// <summary>
        /// Met à jour un style existant à partir d'un objet DTO.
        /// </summary>
        /// <param name="style">Objet DTO représentant le style à mettre à jour.</param>
        /// <returns>Une tâche asynchrone qui indique si la mise à jour a réussi.</returns>
        Task<bool> Update(StyleDTO style);


        /// <summary>
        /// Marque un style comme non valide en fonction de l'identifiant du bonsaï associé.
        /// </summary>
        /// <param name="idBonsai">Identifiant du bonsaï associé au style.</param>
        /// <returns>Une tâche asynchrone qui indique si l'opération a réussi.</returns>
        Task<bool> NotValide(int idBonsai);

    }
}
