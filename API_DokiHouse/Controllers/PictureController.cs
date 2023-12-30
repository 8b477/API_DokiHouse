using BLL_DokiHouse.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_DokiHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PictureController : ControllerBase
    {

        #region Injection
        private readonly IPictureBLLService _pictureRepo;
        private readonly IWebHostEnvironment _env;

        public PictureController(IWebHostEnvironment env, IPictureBLLService pictureRepo)
            => (_env, _pictureRepo) = (env, pictureRepo);
        #endregion


        /// <summary>
        /// Ajoute une image directement enregistrer sur l'app
        /// </summary>
        /// <param name="picture">Image à insérer</param>
        /// <returns></returns>
        [HttpPost("profil")] //-------------------------------------> TODO AJOUT DE FK DANS USER
        public async Task<IActionResult> AddPicture(IFormFile picture)
        {
            string filePath = Path.Combine(_env.ContentRootPath, @"images\profil");

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            filePath = Path.Combine(filePath, picture.FileName);

            using var stream = new FileStream(filePath,FileMode.OpenOrCreate);
            await picture.CopyToAsync(stream);

            return Ok();
        }


        /// <summary>
        /// Ajoute une image de profil dans la base de données sous forme d'un byte[]
        /// </summary>
        /// <param name="file">Image à insérer</param>
        /// <param name="idUser">Identifiant de l'utilisateur</param>
        /// <returns>Retourne un status code 200 ou un 400 si l'ajout a échouer</returns>
        [HttpPost("{idUser}/" + nameof(AddPictureDBProfil))]
        public async Task<IActionResult> AddPictureDBProfil([FromRoute] int idUser,IFormFile file)
        {
            return await _pictureRepo.AddPictureProfil(idUser, file) != 0 ? Ok() : BadRequest();
        }


        /// <summary>
        /// Ajoute une image de Bonsai dans la base de données sous forme d'un byte[]
        /// </summary>
        /// <param name="file">Image à insérer</param>
        /// <returns>Retourne un status code 200 ou un 400 si l'ajout a échouer</returns>
        [HttpPost(nameof(AddPictureDBBonsai))]
        public async Task<IActionResult> AddPictureDBBonsai(IFormFile file)
        {
            return await _pictureRepo.AddPictureBonsai(file) != 0 ? Ok() : BadRequest();
        }

        /// <summary>
        /// Retourne un tableau de byte qui représente une image en base de donnée sur base d'un identifiant
        /// </summary>
        /// <param name="idPictureProfil">Identifiant de type : 'int'</param>
        /// <returns>Retourne byte[]</returns>
        [HttpGet("{idUser}/" + nameof(GetImageProfil))]
        public async Task<IActionResult> GetImageProfil([FromRoute] int idPictureProfil)
        {
            return await _pictureRepo.GetImageProfil(idPictureProfil) is not null ? Ok() : BadRequest();
        }


        /// <summary>
        /// Retourne une collection de tableau de byte qui représente des images en base de donnée sur base d'un identifiant
        /// </summary>
        /// <param name="idUser">Identifiant de type : 'int'</param>
        /// <returns>Retourne Enumerable de byte[]</returns>
        [HttpGet("{idUser}/" + nameof(GetImageBonsai))]
        public async Task<IActionResult> GetImageBonsai([FromRoute] int idUser)
        {
            return await _pictureRepo.GetImageBonsai(idUser) is not null ? Ok() : BadRequest();
        }

    }
}
