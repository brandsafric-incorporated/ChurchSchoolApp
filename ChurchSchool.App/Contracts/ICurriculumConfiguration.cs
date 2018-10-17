using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Application.Contracts
{
    public interface ICurriculumConfiguration
    {
        Domain.Entities.ConfigurationCurriculum Add(Domain.Entities.ConfigurationCurriculum settings);
    }
}
