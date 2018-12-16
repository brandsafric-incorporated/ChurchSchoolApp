using ChurchSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchSchool.Application.Models
{
    public class CurriculumModel
    {
        public long? Id { get; set; }
        public string Description { get; set; }
        public IEnumerable<Domain.Entities.Subject> Subjects { get; set; }
    }
}
