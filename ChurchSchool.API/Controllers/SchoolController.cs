using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchSchool.Application.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChurchSchool.API.Controllers
{

    [Produces("application/json")]    
    [Route("api/[controller]")]    
    [Authorize(Policy = "school-manager")]
    public class SchoolController : ControllerBase
    {
        private ISchool _school;

        public SchoolController(ISchool school)
        {
            _school = school;
        }


        [HttpGet, Route("manager/consolidated-info")]
        public IActionResult GetConsolidatedInfo()
        {
            try
            {
                var data = _school.GetSchoolInfoConsolidated();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}