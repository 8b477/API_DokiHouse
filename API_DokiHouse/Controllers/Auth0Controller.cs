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
            return "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6Ik9BdFdmUlcyX2JOOHY5RjFVUk5FNSJ9.eyJpc3MiOiJodHRwczovL2Rldi1xcTdzMmo0cjB6enJ1a204LnVzLmF1dGgwLmNvbS8iLCJzdWIiOiJFVk5EUmUzTHpRNzhUblppclRlN3JjRG1zdFpIMnVXMEBjbGllbnRzIiwiYXVkIjoiaHR0cHM6Ly9Eb2tpSG91c2UtQmFjayIsImlhdCI6MTcwMzEwNTMyOCwiZXhwIjoxNzAzMTkxNzI4LCJhenAiOiJFVk5EUmUzTHpRNzhUblppclRlN3JjRG1zdFpIMnVXMCIsImd0eSI6ImNsaWVudC1jcmVkZW50aWFscyJ9.Ap2-r3XXAuNwhzp22zo6odQFGnYNkIEcMYhqSlcKwPMYQlNpxMGFsH63gonUYJfIxqUpyJmwNQE6pRnkMPwEtszaqR1vJO6xWw6plN1GxTn8vySKKsgBYH-ma8yr01DHupu3-yh0WNtgsmGawkwf-9Pn2QqaF1ld1jWOPP8cqA5PL8VNPMvCN9nyCeSYqwBOK17smsO97D9O5JIWc5F1bsI6h7BHTsna3tdmWYTCs9gVQMyIwZ2cOZZYuU97Ce6HDGZ0-SHN7pcJ52ei9clCqcB71qlynmCLb5ExrUttwQ_cROkxC9EV5_dqmDMlnTLgUITPBe5m6itLdyKiilAWkA";
        }

    }
}
