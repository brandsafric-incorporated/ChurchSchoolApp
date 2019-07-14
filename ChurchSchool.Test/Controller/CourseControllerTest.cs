using ChurchSchool.API.Controllers;
using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using ChurchSchool.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchSchool.Test.Controller
{
    [TestClass]
    public class CourseControllerTest
    {
        [TestMethod]
        public async Task ShouldReturnListWhenGetAll()
        {
            //arrange
            var mockCourseApp = new Mock<Application.Contracts.ICourse>();
            var mockUnitOfWork = new Mock<IUnitOfWorkIdentity>();
            var mockOptions = new Mock<IOptions<ApplicationSettings>>();

            mockCourseApp.Setup(instance => instance.GetAll())
                         .Returns(GetMockedCourseList())
                         ;

            var controller = new CourseController(mockCourseApp.Object, mockOptions.Object);

            //act
            var result = (await controller.Get()) as OkObjectResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(OkObjectResult), result.GetType());
            Assert.IsInstanceOfType(result.Value, typeof(IEnumerable<Domain.Entities.Course>));
            Assert.IsTrue((result.Value as IEnumerable<Domain.Entities.Course>).Any());
        }

        [TestMethod]
        public async Task ShouldReturnBadRequestWhenGetByNameWithEmptyFilter()
        {
            //arrange
            var mockCourseApp = new Mock<Application.Contracts.ICourse>();
            var mockUnitOfWork = new Mock<IUnitOfWorkIdentity>();
            var mockOptions = new Mock<IOptions<ApplicationSettings>>();

            mockCourseApp.Setup(instance => instance.Filter(It.IsAny<string>()))
                         ;

            var controller = new CourseController(mockCourseApp.Object, mockOptions.Object);

            //act
            var result = await controller.Get(string.Empty);

            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(BadRequestResult), result.GetType());
        }

        [TestMethod]
        public async Task ShouldReturnNotFoundWhenNothingIsFoundOnFilter()
        {
            //arrange
            var mockCourseApp = new Mock<Application.Contracts.ICourse>();
            var mockUnitOfWork = new Mock<IUnitOfWorkIdentity>();
            var mockOptions = new Mock<IOptions<ApplicationSettings>>();

            mockCourseApp.Setup(instance => instance.Filter(It.IsAny<string>()))
                         .Returns(() => { return null; })
                         ;

            var controller = new CourseController(mockCourseApp.Object, mockOptions.Object);

            //act
            var result = await controller.Get("teste");

            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(NotFoundResult), result.GetType());
        }

        [TestMethod]
        public async Task ShouldCreateAnCourseWithValidData()
        {
            //arrange
            var course = new Course
            {
                Name = "Teste",
                Description = "Teste",
                CurrentConfiguration = new CourseConfiguration
                {

                }
            };

            var mockedCourseRepository = new Mock<ICourseRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWorkIdentity>();
            var mockOptions = new Mock<IOptions<ApplicationSettings>>();

            mockedCourseRepository.Setup(g => g.Add(It.IsAny<Domain.Entities.Course>()))
                                  .Returns(() => { return })
                                  ;

            var courseApp = new Application.Course(mockedCourseRepository.Object, mockUnitOfWork.Object);

            var controller = new CourseController(courseApp, mockOptions.Object);

            //act            
            var result = await controller.Post(course) as OkObjectResult;

            var f = await controller.Post(new Course
            {
                Name = "Novo Teste",
                Description = "Descrição do Teste",
                CurrentConfiguration = new CourseConfiguration { }
            });

            Assert.IsNotNull(result);
            var data = result.Value as Domain.Entities.Course;
            Assert.AreEqual(typeof(OkObjectResult), result.GetType());
            Assert.AreEqual(1, data.Id);
        }

        [TestMethod]
        public void ShouldUpdateCourse()
        {

        }


        #region [Help Methods]
        private IEnumerable<Course> GetMockedCourseList()
        {
            return new Course[] {
                    new Course {
                        Id = 1,
                        Name = "Teste",
                        Description = "Teste"
                    },
                    new Course {
                        Id = 2,
                        Name = "Teste 2",
                        Description = "Teste 2"
                    }
            };
        }
        #endregion
    }
}
