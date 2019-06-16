using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository;
using ChurchSchool.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ChurchSchool.Test
{
    [TestClass]
    public class CourseTest
    {
        private DbContextOptions<InMemoryDbContext> _databaseContextOptions;

        [TestInitialize]
        public void Initialize()
        {
            _databaseContextOptions = InMemoryDbHelper.BuildContextOptions();
        }

        [TestMethod]
        public void ShouldCreateAnCourse()
        {
            using (var context = new InMemoryDbContext(_databaseContextOptions))
            {
                //arrange 
                var courseApp = new ChurchSchool.Application.Course(new CourseRepository(context));

                var course = new Domain.Entities.Course
                {
                    CurrentConfiguration = new Domain.Entities.CourseConfiguration
                    {
                        ConfigCurriculumns = new[] {
                            new Domain.Entities.ConfigurationCurriculum{
                                Configuration = new Domain.Entities.CourseConfiguration{
                                    IsCurrentConfiguration = true,
                                    EnrollDocuments = new []{
                                        new CourseDocument{
                                            Type = Domain.Enum.EDocumentType.CPF
                                        },new CourseDocument{
                                            Type = Domain.Enum.EDocumentType.RG
                                        }
                                    }
                                }
                            }
                        },
                        EnrollDocuments = new[]{
                                        new CourseDocument{
                                            Type = Domain.Enum.EDocumentType.CPF
                                        },new CourseDocument{
                                            Type = Domain.Enum.EDocumentType.RG
                                        }
                        },
                        IsCurrentConfiguration = true
                    },
                    Description = "A simple test for a course",
                    Name = " Simple Course"
                };
                //act
                var result = courseApp.Add(course);

                //assert
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Id > 0);
            }

        }

        [TestMethod]
        public void ShoudRefuseCourseWithoutName()
        {
            using (var context = new InMemoryDbContext(_databaseContextOptions))
            {
                //arrange 
                var courseApp = new ChurchSchool.Application.Course(new CourseRepository(context));

                var course = new Domain.Entities.Course
                {
                    CurrentConfiguration = new Domain.Entities.CourseConfiguration
                    {
                        ConfigCurriculumns = new[] {
                            new Domain.Entities.ConfigurationCurriculum{
                                Configuration = new Domain.Entities.CourseConfiguration{
                                    IsCurrentConfiguration = true,
                                    EnrollDocuments = new []{
                                        new CourseDocument{
                                            Type = Domain.Enum.EDocumentType.CPF
                                        },new CourseDocument{
                                            Type = Domain.Enum.EDocumentType.RG
                                        }
                                    }
                                }
                            }
                        },
                        EnrollDocuments = new[]{
                                        new CourseDocument{
                                            Type = Domain.Enum.EDocumentType.CPF
                                        },new CourseDocument{
                                            Type = Domain.Enum.EDocumentType.RG
                                        }
                        },
                        IsCurrentConfiguration = true
                    },
                    Description = "A simple test for a course",
                    Name = string.Empty
                };
                //act
                var result = courseApp.Add(course);

                //assert
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Errors.Any());
                Assert.IsFalse(result.Id > 0);
            }
        }

        [TestMethod]
        public void ShouldRefuseACourseWithoutConfiguration()
        {
            using (var context = new InMemoryDbContext(_databaseContextOptions))
            {
                //arrange 
                var courseApp = new ChurchSchool.Application.Course(new CourseRepository(context));

                var course = new Domain.Entities.Course
                {
                    Description = "A simple test for a course",
                    Name = "Simple Course"
                };
                //act
                var result = courseApp.Add(course);

                //assert
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Errors.Any());
                Assert.IsFalse(result.Id > 0);
            }
        }

        [TestMethod]
        public void ShouldPreventFromSaveCourseNameThatAlreadyExists()
        {
            using (var context = new InMemoryDbContext(_databaseContextOptions))
            {
                //arrange 
                var courseApp = new ChurchSchool.Application.Course(new CourseRepository(context));

                var courseA = new Domain.Entities.Course
                {
                    CurrentConfiguration = new Domain.Entities.CourseConfiguration
                    {
                        ConfigCurriculumns = new[] {
                            new Domain.Entities.ConfigurationCurriculum{
                                Configuration = new Domain.Entities.CourseConfiguration{
                                    IsCurrentConfiguration = true,
                                    EnrollDocuments = new []{
                                        new CourseDocument{
                                            Type = Domain.Enum.EDocumentType.CPF
                                        },new CourseDocument{
                                            Type = Domain.Enum.EDocumentType.RG
                                        }
                                    }
                                }
                            }
                        },
                        EnrollDocuments = new[]{
                                        new CourseDocument{
                                            Type = Domain.Enum.EDocumentType.CPF
                                        },new CourseDocument{
                                            Type = Domain.Enum.EDocumentType.RG
                                        }
                        },
                        IsCurrentConfiguration = true
                    },
                    Description = "A simple test for a course",
                    Name = " Simple Course"
                };

                var courseB = new Domain.Entities.Course
                {
                    CurrentConfiguration = new Domain.Entities.CourseConfiguration
                    {
                        ConfigCurriculumns = new[] {
                            new Domain.Entities.ConfigurationCurriculum{
                                Configuration = new Domain.Entities.CourseConfiguration{
                                    IsCurrentConfiguration = true,
                                    EnrollDocuments = new []{
                                        new CourseDocument{
                                            Type = Domain.Enum.EDocumentType.CPF
                                        },new CourseDocument{
                                            Type = Domain.Enum.EDocumentType.RG
                                        }
                                    }
                                }
                            }
                        },
                        EnrollDocuments = new[]{
                                        new CourseDocument{
                                            Type = Domain.Enum.EDocumentType.CPF
                                        },new CourseDocument{
                                            Type = Domain.Enum.EDocumentType.RG
                                        }
                        },
                        IsCurrentConfiguration = true
                    },
                    Description = "A simple test for a course",
                    Name = " Simple Course"
                };
                //act
                var firstResult = courseApp.Add(courseA);
                context.SaveChanges();

                var secondResult = courseApp.Add(courseB);

                Assert.IsNotNull(firstResult);
                Assert.IsNotNull(secondResult);
                Assert.IsTrue(!firstResult.Errors.Any());
                Assert.IsTrue(secondResult.Errors.Any());

            }
        }
    }
}
