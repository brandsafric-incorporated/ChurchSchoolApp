using ChurchSchool.Application.Contracts;
using ChurchSchool.Domain.Contracts;
using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChurchSchool.Application
{
    public class Subject : ISubject
    {
        private ISubjectRepository _subjectRepository;

        public Subject(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public Domain.Entities.Subject Add(Domain.Entities.Subject entity)
        {
            _subjectRepository.Add(entity);
            return entity;
        }

        public IEnumerable<Domain.Entities.Subject> Filter(string name)
        {
            return GetAll().Where(h => h.Name.Contains(name));
        }

        public IEnumerable<Domain.Entities.Subject> GetAll()
        {
            return _subjectRepository.GetAll();
        }

        public Domain.Entities.Subject GetById(long id)
        {
            return _subjectRepository.Filter(new Domain.Entities.Subject { Id = id })
                                     .FirstOrDefault();
        }

        public ValidationResult Remove(long id)
        {
            _subjectRepository.Remove(id);
            return new ValidationResult();
        }

        public ValidationResult Update(Domain.Entities.Subject entity)
        {
            _subjectRepository.Update(entity);

            return new ValidationResult();
        }
    }
}
