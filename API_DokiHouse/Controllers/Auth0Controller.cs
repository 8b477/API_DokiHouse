using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_DokiHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth0Controller : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public string GetToken()
        {
            return "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6Ik9BdFdmUlcyX2JOOHY5RjFVUk5FNSJ9.eyJpc3MiOiJodHRwczovL2Rldi1xcTdzMmo0cjB6enJ1a204LnVzLmF1dGgwLmNvbS8iLCJzdWIiOiJFVk5EUmUzTHpRNzhUblppclRlN3JjRG1zdFpIMnVXMEBjbGllbnRzIiwiYXVkIjoiaHR0cHM6Ly9Eb2tpSG91c2UtQmFjayIsImlhdCI6MTcwMzE1NTc4MCwiZXhwIjoxNzAzMjQyMTgwLCJhenAiOiJFVk5EUmUzTHpRNzhUblppclRlN3JjRG1zdFpIMnVXMCIsImd0eSI6ImNsaWVudC1jcmVkZW50aWFscyJ9.UaRAGjcmvoN_FCjyMTY3WZuUyBUrfDYj6f1Utw80zsyPwdndQIwlvxGnhBLJB115CcOE9EkTTTl-SdkmxJxhWkO2bD_KtljotgSVeUrALgo4iePikQsibhtUsljNU4JX3c4USgiiQbkbG4rlFOxod2Yn2tuZ6MSGp66VpfBiM9B5rWk7rqzImJ6P8117mHyAhEFFNlj9Hjybrxr-w-MytHW5ELX2mjsvKCv1T3qiUGH6PFpwGEGT34qDPBSa10BVFHKOnTcfMPp5cs5-hFkE_SdXyqQRF7zpdk1T07xUWSeavxIZlbiUQAe-SVQe2QvKiMjIEPeS8LbXsshDA1UM4Q";
        }

    }
}
