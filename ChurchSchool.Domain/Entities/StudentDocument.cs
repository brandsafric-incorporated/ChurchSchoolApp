using ChurchSchool.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChurchSchool.Domain.Entities
{
    public class StudentDocument : Document
    {
        public long StudentId { get; set; }
        public Student Student { get; set; }

        [NotMapped]
        public FileModel File { get; set; }
    }
}
