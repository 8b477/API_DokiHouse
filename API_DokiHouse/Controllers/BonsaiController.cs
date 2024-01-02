using API_DokiHouse.Models;
using BLL_DokiHouse.Interfaces;
using DAL_DokiHouse.DTO;
using Tools_DokiHouse.Filters.JwtIdentifiantFilter;
using API_DokiHouse.Services;
using static API_DokiHouse.Models.BonsaiModel;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API_DokiHouse.Tools;
using BLL_DokiHouse.Models;

namespace API_DokiHouse.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(JwtUserIdentifiantFilter))]
    [AllowAnonymous]
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BonsaiDisplayDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Get()
        {
            IEnumerable<BonsaiAndChild>? result = await _bonsaiService.Get();

            return
                result is not null
                ? Ok(result)
                : NoContent();
        }



        /// <summary>
        /// Récupère tous les bonsaïs lié à l'utilisateur identifié.
        /// </summary>
        /// <returns>
        /// Une action HTTP avec le statut Ok et la liste des bonsaïs si la récupération réussit,
        /// sinon BadRequest ou NoContent si la liste est vide.
        /// </returns>
        [HttpGet(nameof(GetOwnBonsai))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BonsaiDisplayDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetOwnBonsai()
        {

            int idUser = _httpContextService.GetLoggedInUserId();

            if (idUser == 0) return Unauthorized();

            IEnumerable<BonsaiAndChild>? result = await _bonsaiService.Get(idUser);

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BonsaiDisplayDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            BonsaiDisplayDTO? bonsai = await _bonsaiService.GetByID(id);

            return 
                bonsai is not null 
                ? Ok(bonsai) 
                : NoContent();
        }



        /// <summary>
        /// Récupère un bonsaï par son nom.
        /// </summary>
        /// <param name="name">Le nom du bonsaï à récupérer.</param>
        /// <returns>
        /// Une action HTTP avec le statut Ok et le bonsaï récupéré si la récupération réussit,
        /// sinon BadRequest ou NoContent si le bonsaï n'est pas trouvé.
        /// </returns>
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BonsaiDisplayDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetByName([FromRoute] string name)
        {
            IEnumerable<BonsaiDisplayDTO>? bonsai = await _bonsaiService.GetByName(name);
            return 
                bonsai is not null 
                ? Ok(bonsai) 
                : NoContent();
        }



        /// <summary>
        /// Crée un nouveau bonsaï.
        /// </summary>
        /// <param name="model">Le modèle de création du bonsaï.</param>
        /// <returns>
        /// Une action HTTP avec le statut CreatedAtAction et le modèle créé si la création réussit,
        /// sinon BadRequest.
        /// </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(BonsaiCreateModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Create(BonsaiCreateModel model)
        {
            if (!ModelState.IsValid) return BadRequest();
           
            int idToken = _httpContextService.GetLoggedInUserId();

            if(idToken == 0) return Unauthorized();


            BonsaiBLL bonsaiDTO = Mapper.BonsaiModelToBLL(model);

            bonsaiDTO.IdUser = idToken;


            if(await _bonsaiService.Create(bonsaiDTO))
            {
                return CreatedAtAction(nameof(Create), model);
            }

            return BadRequest("fin de create error");
        }



        /// <summary>
        /// Met à jour un bonsaï.
        /// </summary>
        /// <param name="idBonsai">L'identifiant du bonsaï à mettre à jour.</param>
        /// <param name="model">Le modèle de création ou de mise à jour du bonsaï.</param>
        /// <returns>
        /// Une action HTTP avec le statut Ok si la mise à jour réussit, sinon BadRequest.
        /// </returns>
        [HttpPut("{idBonsai}:int")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update(int idBonsai,  BonsaiCreateModel model)
        {

            int idToken = _httpContextService.GetLoggedInUserId();

            if (idToken == 0) return Unauthorized();

            BonsaiDTO bonsaiDTO = new(idBonsai, model.Name, model.Description, idToken);

            return 
                await _bonsaiService.Update(bonsaiDTO) 
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
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(int id)
        {
            return 
                await _bonsaiService.Delete(id) 
                ? NoContent() 
                : BadRequest();
        }




        [AllowAnonymous]
        [HttpGet(nameof(Test))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BonsaiDisplayDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Test()
        {
            var result = await _bonsaiService.GetTest();

            return
                result is not null
                ? Ok(result)
                : NoContent();
        }
    }
}
