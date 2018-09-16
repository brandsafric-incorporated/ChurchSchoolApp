using System;
using System.Linq;
using ChurchSchool.Application.Contracts;
using ChurchSchool.Identity.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChurchSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAccount _account;

        private IAuthorization _authorization;

        public AuthController(IAccount account, IAuthorization authorization)
        {
            _account = account;
            _authorization = authorization;
        }

        [HttpPost, Route("Login")]
        public IActionResult Login([FromBody] Domain.Entities.Identity.Account credentials)
        {
            try
            {
                var loginResult = _authorization.Login(credentials);

                if (string.IsNullOrEmpty(loginResult))
                    return NotFound();
                else
                    return Ok(loginResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpGet, Route("Claims"), Authorize]
        public IActionResult GetUserClaims(string userEmail)
        {
            try
            {
                var result = _authorization.GetUserClaims(userEmail);

                if (result.Any())
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }        

    }
}