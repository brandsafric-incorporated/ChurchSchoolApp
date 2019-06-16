using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Repository.Contracts
{
    public interface IDomainTables
    {
        DbSet<Domain.Entities.Person> People { get; set; }
        DbSet<Domain.Entities.Address> Addresses { get; set; }
        DbSet<Domain.Entities.Student> Students { get; set; }
        DbSet<Domain.Entities.Email> Emails { get; set; }
        DbSet<Domain.Entities.StudentDocument> StudentDocuments { get; set; }
        DbSet<Domain.Entities.PersonDocument> PersonDocuments { get; set; }
        DbSet<Domain.Entities.Course> Courses { get; set; }
        DbSet<Domain.Entities.CourseConfiguration> Configurations { get; set; }
        DbSet<Domain.Entities.Curriculum> Curriculums { get; set; }
        DbSet<Domain.Entities.CourseDocument> CourseDocuments { get; set; }
        DbSet<Domain.Entities.Subject> Subjects { get; set; }
        DbSet<Domain.Entities.Professor> Professors { get; set; }
        DbSet<Domain.Entities.CourseClass> Classes { get; set; }
        DbSet<Domain.Entities.Grade> Grades { get; set; }
        DbSet<Domain.Entities.GradeHistory> GradeHistory { get; set; }
        DbSet<Domain.Entities.Frequency> Frequencies { get; set; }
        DbSet<Domain.Entities.Curriculum_Subject> Curriculum_Subject { get; set; }
        DbSet<Domain.Entities.CourseClass_Student> CourseClass_Student { get; set; }
        DbSet<Domain.Entities.ProfessorSubject> ProfessorSubject { get; set; }
    }
}
