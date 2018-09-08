using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchSchool.API.Models;
using ChurchSchool.Application.Contracts;
using ChurchSchool.Repository;
using ChurchSchool.Repository.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChurchSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccount _account;
        private IUnitOfWorkIdentity _unitOfWork;

        public AccountController(IAccount account,
                                 IUnitOfWorkIdentity unitOfWork
                                 )
        {
            _account = account;
            _unitOfWork = unitOfWork;
        }

        [HttpPost, Authorize(Policy = "student")]
        public IActionResult Post([FromBody]Domain.Entities.Identity.Account account)
        {
            try
            {
                var result = _account.Create(account);

                _unitOfWork.Commit();

                if (result.Errors.Any())
                    return BadRequest(result.Errors);

                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }

        [HttpPut, Authorize(Policy = "student")]
        public IActionResult Put([FromBody]Domain.Entities.Identity.Account account)
        {
            try
            {
                var result = _account.Modify(account);

                _unitOfWork.Commit();

                if (result.Errors.Any())
                    return BadRequest(result.Errors);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet, Route("CheckUserAccount")]
        public IActionResult CheckUserAccount(string userEmail)
        {
            try
            {
                var accountExists = _account.CheckIfUserExists(userEmail);

                if (accountExists)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost, Route("RecoverPassword")]
        public IActionResult RecoverPassword([FromBody] string userEmail)
        {
            try
            {
                _account.RecoverPassword(userEmail);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost, Route("ResetPassword")]
        public IActionResult ResetPassword([FromBody] ResetPasswordModel resetPwdData)
        {
            try
            {
                var result = _account.ResetPassword(resetPwdData.Token, resetPwdData.Password);

                if (!result)
                {
                    return BadRequest(new { result = "Token Inválido" });
                }

                _unitOfWork.Commit();

                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet, Route("CheckResetPasswordToken")]
        public IActionResult CheckResetPasswordToken(string token)
        {
            try
            {
                var isValid = _account.ValidateToken(token);
                if (isValid)
                {
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }
    }
}