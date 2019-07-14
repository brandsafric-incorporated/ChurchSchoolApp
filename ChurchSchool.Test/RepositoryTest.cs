using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository;
using ChurchSchool.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChurchSchool.Test
{
    [TestClass]
    public class RepositoryTest
    {
        private DbContextOptions<InMemoryDbContext> _databaseContextOptions;

        [TestInitialize]
        public void Initialize()
        {
            _databaseContextOptions = InMemoryDbHelper.BuildContextOptions();
        }

        [TestMethod]
        public void InMemoryDbExampleTest()
        {
            using (var context = new InMemoryDbContext(_databaseContextOptions))
            {
                var repository = new PersonRepository(null);
                repository.Add(new Domain.Entities.Person
                {
                    Addresses = new List<Address>() {
                            new Domain.Entities.Address{
                                AddressTypeId = (int)Domain.Enum.EAddressType.HOME,
                                CityId = 1,
                                Details = string.Empty,
                                Neighborhood = "Teste",
                                PostalCode = "04550900",
                                StreetName = "Test Street",
                                State = "SP",
                                StreetNumber = "100"
                            }
                        },
                    BirthDate = new DateTime(2000, 01, 01),
                    Documents = new List<Domain.Entities.PersonDocument>() {
                            new Domain.Entities.PersonDocument
                            {
                             DocumentNumber = "0236551349",
                             DocumentTypeId = (int)Domain.Enum.EDocumentType.RG,
                             IssuingDate = new DateTime(2000,01,01),
                             IssuingEntity = "Test"
                            }
                        },
                    FirstName = "Test First Name",
                    MiddleName = "Test Middle Name",
                    LastName = "Test Last Name",
                    Sex = Domain.Enum.ESex.MALE,
                    ProfileImage = "",
                    Email = new Email
                    {
                        Address = "email@email.com"
                    },
                    Phones = new List<Domain.Structs.Phone> {
                            new Domain.Structs.Phone
                            {
                                AreaCode = "55",
                                Number = "22317987"
                            }
                        }
                });

                context.SaveChanges();
            }

            using (var context = new InMemoryDbContext(_databaseContextOptions))
            {
                Assert.AreEqual(1, context.People.CountAsync().Result);
                Assert.AreEqual("Test First Name", context.People.SingleAsync().Result.FirstName);
            }
        }
    }
}
