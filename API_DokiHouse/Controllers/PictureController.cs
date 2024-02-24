using API_DokiHouse.Tools;
using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Models.FilePicture;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tools_DokiHouse.Filters.JwtIdentifiantFilter;



namespace API_DokiHouse.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(JwtUserIdentifiantFilter))]
    [ApiController]
    public class PictureController : ControllerBase
    {

        #region Injection
        private readonly IPictureBLLService _pictureRepo;
        private readonly IWebHostEnvironment _env;
        private readonly GetInfosHTTPContext _getInfosHTTPContext;
        private readonly GetDomainService _getDomainService;

        public PictureController(IWebHostEnvironment env, IPictureBLLService pictureRepo, GetInfosHTTPContext getInfosHTTPContext, GetDomainService getDomainService)
            => (_env, _pictureRepo, _getInfosHTTPContext, _getDomainService)
            = (env, pictureRepo, getInfosHTTPContext, getDomainService);
        #endregion


        /// <summary>
        /// Ajoute une image pour un bonsaï.
        /// </summary>
        /// <param name="picture">Fichier image à télécharger.</param>
        /// <param name="idBonsai">ID du bonsaï auquel attacher l'image.</param>
        /// <returns>Retourne un résultat HTTP. 201 Created si réussi, 400 Bad Request en cas d'échec.</returns>
        [HttpPost("{idBonsai:int}")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> AddPicture(IFormFile picture, int idBonsai)
        {
            int idToken = _getInfosHTTPContext.GetIdUserTokenInHttpContext();
            if (idToken == 0) return Unauthorized();

            string userName = _getInfosHTTPContext.GetNameUserTokenInHttpContext();
            if (userName == string.Empty) return Unauthorized();


            string uniqueFileNameFolder = idToken.ToString() + "_" + userName.ToUpper();

            FilePictureModel filePicture = new()
            {
                IdBonsai = idBonsai,
                File = picture,
                FilePath = Path.Combine(_env.ContentRootPath, @"images\bonsais", uniqueFileNameFolder),
                FileName = picture.FileName,
                FileFolder = uniqueFileNameFolder
            };

            string domain = _getDomainService.GetCurrentDomainName();

            bool result = await _pictureRepo.AddPictureBonsai(filePicture, idBonsai, domain, idToken.ToString(), userName.ToUpper());

            return result ? CreatedAtAction(nameof(AddPicture), filePicture) : BadRequest();
        }

        [AllowAnonymous]
        [HttpGet("api/images/bonsais/{uniqueFileNameFolder}/{uniqueFileName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetImage(string uniqueFileNameFolder, string uniqueFileName)
        {
            var imagePath = Path.Combine(_env.ContentRootPath, @"images\bonsais", uniqueFileNameFolder, uniqueFileName);

            if (!System.IO.File.Exists(imagePath))
            {
                return NotFound();
            }

            string fileExtension = Path.GetExtension(uniqueFileName);

            string mimeType = _pictureRepo.GetMimeTypeFromExtension(fileExtension);

            var imageBytes = System.IO.File.ReadAllBytes(imagePath);

            return File(imageBytes, mimeType);
        }


        [AllowAnonymous]
        [HttpGet(nameof(Test))]
        public IActionResult Test()
        {

           
            string test1 = _getDomainService.GetCurrentDomainName(); // recup ici le https://localhost:7043/api/
            string test2 = ""; // Ici je recup le nom du controller Picture/
            string test3 = ""; // ici je cherche le nom de la méthode Test/

            return Ok(test1);
        }
    }
}
