using BLL_DokiHouse.Interfaces;

using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace API_DokiHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class Auth0Controller : ControllerBase
    {

        #region Injection

        //private readonly IMemoryCache _memoryCach;
        private readonly ILogger<Auth0Controller> _logger;
        private readonly IUserBLLService _repo;

        public Auth0Controller
            (ILogger<Auth0Controller> logger, IUserBLLService repo)
            => (_logger, _repo) = (logger, repo); 

        #endregion

        [HttpGet]
        public string GetToken()
        {
            return "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6Ik9BdFdmUlcyX2JOOHY5RjFVUk5FNSJ9.eyJpc3MiOiJodHRwczovL2Rldi1xcTdzMmo0cjB6enJ1a204LnVzLmF1dGgwLmNvbS8iLCJzdWIiOiJFVk5EUmUzTHpRNzhUblppclRlN3JjRG1zdFpIMnVXMEBjbGllbnRzIiwiYXVkIjoiaHR0cHM6Ly9Eb2tpSG91c2UtQmFjayIsImlhdCI6MTcwMzE1NTc4MCwiZXhwIjoxNzAzMjQyMTgwLCJhenAiOiJFVk5EUmUzTHpRNzhUblppclRlN3JjRG1zdFpIMnVXMCIsImd0eSI6ImNsaWVudC1jcmVkZW50aWFscyJ9.UaRAGjcmvoN_FCjyMTY3WZuUyBUrfDYj6f1Utw80zsyPwdndQIwlvxGnhBLJB115CcOE9EkTTTl-SdkmxJxhWkO2bD_KtljotgSVeUrALgo4iePikQsibhtUsljNU4JX3c4USgiiQbkbG4rlFOxod2Yn2tuZ6MSGp66VpfBiM9B5rWk7rqzImJ6P8117mHyAhEFFNlj9Hjybrxr-w-MytHW5ELX2mjsvKCv1T3qiUGH6PFpwGEGT34qDPBSa10BVFHKOnTcfMPp5cs5-hFkE_SdXyqQRF7zpdk1T07xUWSeavxIZlbiUQAe-SVQe2QvKiMjIEPeS8LbXsshDA1UM4Q";
        }

        #region ZONE TEST

        //[HttpGet(nameof(Test))]
        //public async Task<IEnumerable<UserDisplayDTO>> Test()
        //{

        //    string cacheKey = "laClef";

        //    if (!_memoryCach.TryGetValue(cacheKey, out IEnumerable<UserDisplayDTO> users))
        //    {
        //        _logger.LogError("users trouvers dans le cache");
        //    }
        //    else
        //    {
        //        _logger.LogError("user pas trouver dans le cahce");
        //        users = await _repo.Get();


        //        var cacheEntryOptions = new MemoryCacheEntryOptions()
        //                .SetSlidingExpiration(TimeSpan.FromSeconds(45))
        //                .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
        //                .SetPriority(CacheItemPriority.Normal);

        //        _memoryCach.Set(cacheKey, users, cacheEntryOptions);
        //    }

        //    _logger.LogError("le cache se vide");

        //    return users;
        //} 
        #endregion

    }
}
