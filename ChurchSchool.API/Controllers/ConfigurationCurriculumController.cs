using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchSchool.Application.Contracts;
using ChurchSchool.Repository.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChurchSchool.API.Controllers
{
    [Route("api/Curriculum/Settings")]
    [ApiController]
    [Authorize]
    public class ConfigurationCurriculumController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurriculumConfiguration _curriculumConfiguration;


        public ConfigurationCurriculumController(
            IUnitOfWork unitOfWork,
            ICurriculumConfiguration curriculumConfiguration
        )
        {
            _unitOfWork = unitOfWork;
            _curriculumConfiguration = curriculumConfiguration;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Domain.Entities.ConfigurationCurriculum settings)
        {
            try
            {
                var result = _curriculumConfiguration.Add(settings);

                _unitOfWork.Commit();

                if (result.Errors.Any())
                {
                    return BadRequest(result.Errors);
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}