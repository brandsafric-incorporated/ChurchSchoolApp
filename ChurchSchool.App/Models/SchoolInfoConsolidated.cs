using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Application.Models
{
    public class SchoolInfoConsolidated
    {
        public long ActiveCoursesAmount { get; set; }
        public long PendingEnrollmentsAmount { get; set; }
        public long ActiveStudentsAmount { get; set; }
        public long AvaiableTeachersAmount { get; set; }
    }
}
