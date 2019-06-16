using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Repository.Helpers
{
    public class ModelBuilderFactory
    {
        public static void ConfigureDomainModels(ModelBuilder modelBuilder)
        {
            new ModelSettings.Student().Configure(modelBuilder);
            new ModelSettings.Person().Configure(modelBuilder);
            new ModelSettings.StudentDocument().Configure(modelBuilder);
            new ModelSettings.Address().Configure(modelBuilder);
            new ModelSettings.Email().Configure(modelBuilder);
            new ModelSettings.Phone().Configure(modelBuilder);
            new ModelSettings.Course().Configure(modelBuilder);
            new ModelSettings.CourseConfiguration().Configure(modelBuilder);
            new ModelSettings.Curriculum().Configure(modelBuilder);
            new ModelSettings.CourseDocuments().Configure(modelBuilder);
            new ModelSettings.Subject().Configure(modelBuilder);
            new ModelSettings.Professor().Configure(modelBuilder);
            new ModelSettings.CourseClass().Configure(modelBuilder);
            new ModelSettings.CourseClass_Student().Configure(modelBuilder);
            new ModelSettings.Professor_Subject().Configure(modelBuilder);
            new ModelSettings.Curriculum_Subject().Configure(modelBuilder);
            new ModelSettings.ConfigurationCurriculum().Configure(modelBuilder);
        }
    }
}
