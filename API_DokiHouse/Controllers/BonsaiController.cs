using API_DokiHouse.Models;
using API_DokiHouse.Tools;
using BLL_DokiHouse.Interfaces;
using Tools_DokiHouse.Filters.JwtIdentifiantFilter;
using Microsoft.AspNetCore.Mvc;
using Entities_DokiHouse.Entities;
using Microsoft.AspNetCore.Authorization;
using BLL_DokiHouse.Models.Bonsai.View;



namespace API_DokiHouse.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(JwtUserIdentifiantFilter))]
    [ApiController]
    public class BonsaiController : ControllerBase
    {

        #region Injection
        private readonly IBonsaiBLLService _bonsaiService;

        private readonly GetInfosHTTPContext _httpContextService;

        public BonsaiController(IBonsaiBLLService bonsaiService, GetInfosHTTPContext httpContextService)
        {
            _bonsaiService = bonsaiService;
            _httpContextService = httpContextService;
        }


        #endregion


        /// <summary>
        /// Récupère tous les bonsaïs en base de données.
        /// </summary>
        /// <returns>
        /// Retourne la liste des bonsaïs si la récupération réussit, sinon une liste vide.
        /// </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Bonsai>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Bonsai?> result = await _bonsaiService.GetBonsais();

            return
                result is not null
                ? Ok(result)
                : NoContent();
        }


        /// <summary>
        /// Récupère tous les bonsaïs en base de données en relation avec l'utilisateur préalablement log.
        /// </summary>
        /// <returns>
        /// Retourne la liste des bonsaïs de l'utilisateur ,  sinon aucune correspondance renvoie null.
        /// </returns>
        [HttpGet(nameof(GetOwnBonsaiAndPicture))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BonsaiPictureDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetOwnBonsaiAndPicture()
        {

            int idUser = _httpContextService.GetIdUserTokenInHttpContext();

            if (idUser == 0) return Unauthorized();

            var result = await _bonsaiService.GetBonsaiAndPicture(idUser);

            return
                result is not null
                ? Ok(result)
                : NoContent();
        }


        /// <summary>
        /// Récupère tous les bonsaïs en base de données.
        /// </summary>
        /// <returns>
        /// Retourne la liste des bonsaïs si la récupération réussit, sinon une liste vide.
        /// </returns>
        [AllowAnonymous]
        [HttpGet(nameof(GetAllBonsaiAndPicture))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BonsaiPictureDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllBonsaiAndPicture()
        {
            var result = await _bonsaiService.GetAllBonsaiAndPicture();

            return
                result is not null
                ? Ok(result)
                : NoContent();
        }


        /// <summary>
        /// Récupère tous les bonsaïs liés à l'utilisateur identifié.
        /// </summary>
        /// <returns>
        /// Une action HTTP avec le statut Ok et la liste des bonsaïs si la récupération réussit,
        /// sinon BadRequest ou NoContent si la liste est vide.
        /// </returns>
        [HttpGet(nameof(Owned))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Bonsai>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Owned()
        {
            int idUser = _httpContextService.GetIdUserTokenInHttpContext();

            if (idUser == 0) return Unauthorized();

            IEnumerable<Bonsai?> result = await _bonsaiService.GetOwnBonsai(idUser);

            return
                result is not null
                ? Ok(result)
                : NoContent();
        }


        /// <summary>
        /// Récupère un bonsaï par son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du bonsaï à récupérer.</param>
        /// <returns>
        /// Une action HTTP avec le statut Ok et le bonsaï récupéré si la récupération réussit,
        /// sinon BadRequest ou NoContent si le bonsaï n'est pas trouvé.
        /// </returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Bonsai))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Bonsai? bonsai = await _bonsaiService.GetBonsaiByID(id);

            return
                bonsai is not null
                ? Ok(bonsai)
                : NoContent();
        }


        /// <summary>
        /// Récupère un bonsaï par son nom.
        /// </summary>
        /// <param name="name">Le nom du bonsaï à récupérer.</param>
        /// <param name="stringIdentifiant">Le nom de la colonne en DB à comparer avec la recherche, par défaut sa valeur est : 'Name'.</param>
        /// <returns>
        /// Une action HTTP avec le statut Ok et le bonsaï récupéré si la récupération réussit,
        /// sinon BadRequest ou NoContent si le bonsaï n'est pas trouvé.
        /// </returns>
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Bonsai))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetByName([FromRoute] string name, string stringIdentifiant = "Name")
        {
            IEnumerable<Bonsai>? bonsai = await _bonsaiService.GetBonsaiByName(name, stringIdentifiant);
            return
                bonsai is not null
                ? Ok(bonsai)
                : NoContent();
        }


        /// <summary>
        /// Crée un nouveau bonsaï.
        /// </summary>
        /// <param name="bonsai">Le modèle de création du bonsaï.</param>
        /// <returns>
        /// Une action HTTP avec le statut CreatedAtAction et le modèle créé si la création réussit,
        /// sinon BadRequest.
        /// </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(BonsaiView))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Create(BonsaiModel bonsai)
        {
            if (!ModelState.IsValid) return BadRequest();

            int idToken = _httpContextService.GetIdUserTokenInHttpContext();

            if (idToken == 0) return Unauthorized();

            BonsaiView? bonsaiView = await _bonsaiService.CreateBonsai(bonsai, idToken);

            return
                  bonsaiView is not null
                ? CreatedAtAction(nameof(Create), bonsaiView)
                : BadRequest();
        }


        /// <summary>
        /// Met à jour un bonsaï.
        /// </summary>
        /// <param name="bonsai">Le modèle de création ou de mise à jour du bonsaï.</param>
        /// <param name="idBonsai">L'identifiant de type INT du Bonsai à mettre à jour.</param>
        /// <returns>
        /// Une action HTTP avec le statut Ok si la mise à jour réussit, sinon BadRequest.
        /// </returns>
        [HttpPut("{idBonsai:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update(BonsaiModel bonsai, [FromRoute] int idBonsai)
        {
            int idToken = _httpContextService.GetIdUserTokenInHttpContext();

            if (idToken == 0) return Unauthorized();

            return
                await _bonsaiService.UpdateBonsai(bonsai, idBonsai)
                ? Ok()
                : BadRequest();
        }


        /// <summary>
        /// Supprime un bonsaï par son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du bonsaï à supprimer.</param>
        /// <returns>
        /// Une action HTTP avec le statut NoContent si la suppression réussit, sinon BadRequest.
        /// </returns>
        [HttpDelete("{idBonsai:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return
                await _bonsaiService.DeleteBonsai(id)
                ? NoContent()
                : BadRequest();
        }

    }
}
