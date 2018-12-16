using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Application.Models
{
    public class CourseConfigurationViewModel
    {
        public Guid? CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public string Description { get; set; }
        public int PercentageOfAbsenseByClass { get; set; }
        public int LowestGradetoBeApproved { get; set; }

        public CourseViewModel RelatedCourse { get; set; }

        public IEnumerable<Domain.Entities.CourseDocuments> EnrollDocuments { get; set; }
        
        public bool IsCurrent { get; set; }
    }
}
