using ChurchSchool.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Application.Contracts
{
    public interface ISchool
    {
        SchoolInfoConsolidated GetSchoolInfoConsolidated();
    }
}
