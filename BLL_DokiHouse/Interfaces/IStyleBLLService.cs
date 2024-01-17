using API_DokiHouse.Models;

namespace BLL_DokiHouse.Interfaces
{
    public interface IStyleBLLService
    {

        /// <summary>
        /// Crée un nouveau style en utilisant les informations fournies dans l'objet de logique métier style.
        /// </summary>
        /// <param name="style">Objet de logique métier style à créer.</param>
        /// <returns>Une tâche asynchrone indiquant si la création a réussi (true) ou échoué (false).</returns>
        Task<bool> CreateStyle(int idBonsai, StyleModel style);


        /// <summary>
        /// Met à jour un style existant en utilisant les informations fournies dans l'objet de logique métier style.
        /// </summary>
        /// <param name="style">Objet de logique métier style à mettre à jour.</param>
        /// <returns>Une tâche asynchrone indiquant si la mise à jour a réussi (true) ou échoué (false).</returns>
        Task<bool> UpdateStyle(int idStyle, StyleModel style);


        /// <summary>
        /// Supprime un style en base de données via son identifiant.
        /// </summary>
        /// <param name="idStyle">Identifiant de type INT</param>
        /// <returns>Retourne TRUE si la suppression à réussi si non retourne FALSE.</returns>
        Task<bool> DeleteStyle(int idStyle);
    }
}
