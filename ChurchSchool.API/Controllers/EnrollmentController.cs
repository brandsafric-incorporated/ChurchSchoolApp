using ChurchSchool.Application.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ChurchSchool.API.Controllers
{

    [Authorize]
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

        [HttpGet, Route("Pending")]
        public IActionResult GetPendingEnrollments()
        {
            try
            {
                var pendingEnrollments = _enrollment.GetPendingEnrollments();

                if (pendingEnrollments.Any())
                    return Ok(pendingEnrollments);
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}