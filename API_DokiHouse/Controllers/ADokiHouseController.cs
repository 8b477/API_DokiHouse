using BLL_DokiHouse.Interfaces;
using DAL_DokiHouse.DTO;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API_DokiHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ADokiHouseController : ControllerBase
    {


        #region Injection

        private readonly IADokiHouseBLLService _dokiHouseBLLService;
        public ADokiHouseController(IADokiHouseBLLService dokiHouseBLLService) => _dokiHouseBLLService = dokiHouseBLLService;

        #endregion
         

           //_______________________________
          //                               /
         //           GLOBAL INFOS        /
        //______________________________ /

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EveryDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            IEnumerable<EveryDTO>? result = await _dokiHouseBLLService.GetInfos(cancellationToken);

            return
                result is not null
                ? Ok(result)
                : NoContent();
        }


        [HttpGet(nameof(GetPageSize))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EveryDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetPageSize([FromQuery] int startIndex, [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            if (startIndex < 1 || pageSize < 1)
                return BadRequest("La page et la taille de la page doivent être des valeurs positives.");

            IEnumerable<EveryDTO>? result = await _dokiHouseBLLService.GetInfosPaginated(startIndex, pageSize, cancellationToken);

            return
                result is not null
                ? Ok(result)
                : NoContent();
        }

    }
}
