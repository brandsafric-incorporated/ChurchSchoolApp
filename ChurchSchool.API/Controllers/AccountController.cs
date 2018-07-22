using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchSchool.Application.Contracts;
using ChurchSchool.Repository;
using ChurchSchool.Repository.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChurchSchool.API.Controllers
{
    [Authorize(Policy = "student")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccount _account;
        private IUnitOfWorkIdentity _unitOfWork;

        
        public AccountController(IAccount account, IUnitOfWorkIdentity unitOfWork)
        {
            _account = account;
            _unitOfWork = unitOfWork;           
        }

        [HttpPost]
        public IActionResult Post([FromBody]Domain.Entities.Account account)
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

        [HttpPut]
        public IActionResult Put([FromBody]Domain.Entities.Account account)
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
    }
}