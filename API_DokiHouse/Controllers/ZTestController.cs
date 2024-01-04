//using BLL_DokiHouse.Interfaces;
//using DAL_DokiHouse.DTO;

//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Caching.Memory;

//namespace API_DokiHouse.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    [AllowAnonymous]
//    public class TestController : ControllerBase
//    {

//        #region Injection

//        private readonly IMemoryCache _memoryCach;
//        private readonly ILogger<TestController> _logger;
//        private readonly IUserBLLService _repo;

//        public TestController
//            (ILogger<TestController> logger, IUserBLLService repo, IMemoryCache memoryCach)
//            => (_logger, _repo, _memoryCach) = (logger, repo, memoryCach);

//        #endregion


//        #region ZONE TEST

//        [HttpGet(nameof(TestCache))]
//        public async Task<ActionResult<IEnumerable<UserDTO>>> TestCache()
//        {
//            // Utilisation de ActionResult pour pouvoir renvoyer un code HTTP spécifique en cas d'erreur
//            try
//            {
//                string cacheKey = "laClef";

//                // Utilisation de TryGetValue correctement pour vérifier si la valeur existe dans le cache
//                if (!_memoryCach.TryGetValue(cacheKey, out IEnumerable<UserDTO> users))
//                {
//                    _logger.LogError("Les utilisateurs ne sont pas trouvés dans le cache");
//                    users = await _repo.Get();

//                    var cacheEntryOptions = new MemoryCacheEntryOptions()
//                        .SetSlidingExpiration(TimeSpan.FromSeconds(45))
//                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
//                        .SetPriority(CacheItemPriority.Normal);

//                    _memoryCach.Set(cacheKey, users, cacheEntryOptions);
//                }
//                else
//                {
//                    _logger.LogError("Les utilisateurs sont trouvés dans le cache");
//                }

//                // Utilisation du niveau approprié pour les logs (Information plutôt que Error)
//                _logger.LogError("Le cache est vidé");

//                return Ok(users); // Retourne 200 OK avec les utilisateurs
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"Une erreur s'est produite : {ex.Message}");
//                return StatusCode(500, "Une erreur interne s'est produite"); // Retourne 500 Internal Server Error en cas d'erreur
//            }
//        }

//        #endregion

//    }
//}
