using Microsoft.AspNetCore.Http;

namespace BLL_DokiHouse.Interfaces
{
    public interface IPictureBLLService
    {
        /// <summary>
        /// Ajoute une image de Bonsai pour un utilisateur et met à jour la table User avec l'identifiant de l'image.
        /// </summary>
        /// <param name="idUser">Identifiant de l'utilisateur associé à l'image du Bonsai.</param>
        /// <param name="file">Fichier image à associer au Bonsai.</param>
        /// <returns>Identifiant de l'image du bonsai ajoutée.</returns>
        Task<bool> AddPictureBonsai(IFormFile file, string filePath, int idBonsai);
    }
}


///// <summary>
///// Ajoute une image associée à un bonsaï et retourne l'identifiant de l'image ajoutée.
///// </summary>
///// <param name="file">Fichier image à associer au bonsaï.</param>
///// <returns>Identifiant de l'image ajoutée.</returns>
//Task<int> AddPictureProfil(int idUser, IFormFile file);


///// <summary>
///// Récupère l'image de profil associée à un identifiant d'image.
///// </summary>
///// <param name="idPicture">Identifiant de l'image de profil.</param>
///// <returns>Image de profil associée à l'identifiant.</returns>
//Task<byte[]?> GetImageProfil(int idPicture);


///// <summary>
///// Récupère les images associées à un utilisateur pour les bonsaïs.
///// </summary>
///// <param name="idUser">Identifiant de l'utilisateur.</param>
///// <returns>Collection d'images de bonsaï associées à l'utilisateur.</returns>
//Task<IEnumerable<byte[]?>> GetImageBonsai(int idUser);