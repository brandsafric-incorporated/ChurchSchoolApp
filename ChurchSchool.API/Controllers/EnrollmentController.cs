using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchSchool.Application.Contracts;
using ChurchSchool.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChurchSchool.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EnrollmentController : Controller
    {
        private readonly IEnrollment _enrollment;


        public EnrollmentController(IEnrollment enrollment)
        {
            _enrollment = enrollment;
        }

        [HttpGet]
        [Route("Student/{studentDocument}")]
        public IActionResult FilterEnrollmentsByStudent(string studentDocument)
        {
            try
            {
                var student = new Domain.Entities.Student();              

                
                return null;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("Course/{classKey}")]
        public IActionResult FilterEnrollmentsByCourse(Guid classKey)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}