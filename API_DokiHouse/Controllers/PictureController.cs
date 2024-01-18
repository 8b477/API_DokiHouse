using API_DokiHouse.Tools;
using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Models.FilePicture;
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

        public PictureController(IWebHostEnvironment env, IPictureBLLService pictureRepo, GetInfosHTTPContext getInfosHTTPContext)
            => (_env, _pictureRepo, _getInfosHTTPContext) 
            =  (env, pictureRepo, getInfosHTTPContext);
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


            bool result = await _pictureRepo.AddPictureBonsai(filePicture, idBonsai);

            return result ? CreatedAtAction(nameof(AddPicture), filePicture) : BadRequest();
        }

    }
}
