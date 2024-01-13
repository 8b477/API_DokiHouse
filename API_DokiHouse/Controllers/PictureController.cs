using API_DokiHouse.Tools;
using BLL_DokiHouse.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tools_DokiHouse.Filters.JwtIdentifiantFilter;

namespace API_DokiHouse.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(JwtUserIdentifiantFilter))]
    [ApiController]
    [AllowAnonymous]
    public class PictureController : ControllerBase
    {

        #region Injection
        private readonly IPictureBLLService _pictureRepo;
        private readonly IWebHostEnvironment _env;
        private readonly GetInfosHTTPContext _getInfosHTTPContext;

        public PictureController(IWebHostEnvironment env, IPictureBLLService pictureRepo, GetInfosHTTPContext getInfosHTTPContext)
            => (_env, _pictureRepo, _getInfosHTTPContext) 
            =  (env, pictureRepo, getInfosHTTPContext);
        #endregion


        /// <summary>
        /// Ajoute une image directement enregistrer sur le server et la lie au bonsai via son id.
        /// </summary>
        /// <param name="picture">Image à insérer</param>
        /// <param name="idBonsai">Identifiant du Bonsai lié à l'ajout de l'image</param>
        /// <returns></returns>
        [HttpPost("{idBonsai}:int")]
        public async Task<IActionResult> AddPicture(IFormFile picture, int idBonsai)
        {

            int idToken = _getInfosHTTPContext.GetIdUserTokenInHttpContext();
            if (idToken == 0) return Unauthorized();

            string userName = _getInfosHTTPContext.GetNameUserTokenInHttpContext();
            if (userName == string.Empty) return Unauthorized();


            string uniqueFileName = idToken.ToString() + "_" + userName.ToUpper();
            string filePath = Path.Combine(_env.ContentRootPath, @"images\bonsais", uniqueFileName);

            bool result = await _pictureRepo.AddPictureBonsai(picture, filePath, idBonsai);

            return result ? CreatedAtAction(nameof(AddPicture),picture) : BadRequest();
        }

    }
}

/*
   /// <summary>
        /// Ajoute une image de profil dans la base de données sous forme d'un byte[]
        /// </summary>
        /// <param name="file">Image à insérer</param>
        /// <param name="idUser">Identifiant de l'utilisateur</param>
        /// <returns>Retourne un status code 200 ou un 400 si l'ajout a échouer</returns>
        [HttpPost("{idUser}/" + nameof(AddPictureDBProfil))]
        public async Task<IActionResult> AddPictureDBProfil([FromRoute] int idUser,IFormFile file)
        {



            return 
                await _pictureRepo.AddPictureProfil(idUser, file) != 0
                ? Ok() 
                : BadRequest();
        }


        /// <summary>
        /// Ajoute une image de Bonsai dans la base de données sous forme d'un byte[]
        /// </summary>
        /// <param name="file">Image à insérer</param>
        /// <returns>Retourne un status code 200 ou un 400 si l'ajout a échouer</returns>
        [HttpPost(nameof(AddPictureDBBonsai))]//--delete faire la save sur le server
        public async Task<IActionResult> AddPictureDBBonsai(IFormFile file)
        {
            return 
                await _pictureRepo.AddPictureBonsai(file) != 0 
                ? Ok() 
                : BadRequest();
        }


        /// <summary>
        /// Retourne un tableau de byte qui représente une image en base de donnée sur base d'un identifiant
        /// </summary>
        /// <param name="idPictureProfil">Identifiant de type : 'int'</param>
        /// <returns>Retourne byte[]</returns>
        [HttpGet("{idUser}/" + nameof(GetImageProfil))]
        public async Task<IActionResult> GetImageProfil([FromRoute] int idPictureProfil)
        {
            return 
                await _pictureRepo.GetImageProfil(idPictureProfil) is not null 
                ? Ok() 
                : BadRequest();
        }


        /// <summary>
        /// Retourne une collection de tableau de byte qui représente des images en base de donnée sur base d'un identifiant
        /// </summary>
        /// <param name="idUser">Identifiant de type : 'int'</param>
        /// <returns>Retourne Enumerable de byte[]</returns>
        [HttpGet("{idUser}/" + nameof(GetImageBonsai))]
        public async Task<IActionResult> GetImageBonsai([FromRoute] int idUser)
        {
            return 
                await _pictureRepo.GetImageBonsai(idUser) is not null 
                ? Ok() 
                : BadRequest();
        }
 */