﻿
using DAL_DokiHouse.Interfaces.Generic;
using Entities_DokiHouse.Entities;

namespace DAL_DokiHouse.Interfaces
{
    public interface ICommentsRepo : IBaseRepo<Comments, int, string>
    {
        /// <summary>
        /// Crée un nouveau commentaire.
        /// </summary>
        /// <param name="comments">Les données du commentaire à créer.</param>
        /// <returns>Retourne vrai si la création est réussie, sinon faux.</returns>
        Task<bool> Create(int idPost, Comments comments);


        /// <summary>
        /// Met à jour les informations d'un commentaire.
        /// </summary>
        /// <param name="comments">Les données mises à jour du commentaire.</param>
        /// <returns>Retourne vrai si la mise à jour est réussie, sinon faux.</returns>
        Task<bool> Update(int id, Comments comments);


        /// <summary>
        /// Récupère la liste des commentaires associé à l'identifiant d'un Utilisateur
        /// </summary>
        /// <param name="idUser">L'identifiant sur le quelle la recherche se base</param>
        /// <returns>Retourne une liste de commentaires, si pas de commentaire associé retrouver retourne null</returns>
        Task<IEnumerable<Comments>?> GetOwnComments(int id);


        /// <summary>
        /// Check en base de donnée si un Utilisateur détient déjà un comment
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        Task<bool> NotValide(int idUser);
    }

}
