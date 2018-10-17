using ChurchSchool.Application.Models;
using ChurchSchool.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ChurchSchool.Application.Contracts
{
    public interface ICurriculum : IBasicOperations<Domain.Entities.Curriculum>
    {
        IEnumerable<CurriculumModel> GetAll();
        Curriculum_Subject VinculateSubject(Curriculum_Subject curriculum_Subject);
    }
}
