using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChurchSchool.Repository
{
    public class StudentRepository : IRepository<Student>
    {
        private IDatabase _database;

        public StudentRepository(IDatabase database)
        {
            _database = database;
        }

        public Student Add(Student model)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Student> Filter(Student model)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid key)
        {
            throw new NotImplementedException();
        }

        public bool Update(Student model)
        {
            throw new NotImplementedException();
        }
    }
}
