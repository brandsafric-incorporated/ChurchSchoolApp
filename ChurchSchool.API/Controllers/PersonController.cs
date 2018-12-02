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
    [Produces("application/json")]
    [Route("api/Person")]    
    public class PersonController : Controller
    {
        private IPerson _person;
        private IAccount _account;
        private IUnitOfWork _unitOfWork;

        public PersonController(
            IPerson person, 
            IAccount account,
            IUnitOfWork unitOfWork)
        {
            _person = person;
            _account = account;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _person.GetAll();
                return Ok(result.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet, Route("Filter/{accountEmail}")]
        public IActionResult Get([FromRoute]string accountEmail)
        {
            try
            {
                var account = _account.FindbyEmailAccount(accountEmail);

                if (account == null)
                    return NotFound();

                var result = _person.GetById(account.PersonId ?? default(Guid));

                if (result != null)
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpGet, Route("Filter/CPF/{cpf}")]
        public IActionResult Filter([FromRoute] long cpf)
        {
            try
            {
                var person = _person.FilterByCPF(cpf);

                if (person != null)
                    return Ok(person);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Domain.Entities.Person person)
        {
            try
            {
                var result = _person.Add(person);

                if (result.Errors.Any())
                {
                    return BadRequest(result.Errors);
                }

                _unitOfWork.Commit();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}