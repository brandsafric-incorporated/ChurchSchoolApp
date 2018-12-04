using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChurchSchool.Repository.Repositories
{
    //public class CourseSubjectRepository : ICourseSubjectRepository
    //{

    //    private RepositoryContext _context;

    //    public CourseSubjectRepository(RepositoryContext context)
    //    {
    //        _context = context;
    //    }

    //    public Course_Subject Add(Course_Subject model)
    //    {
    //        _context.Course_Subject.Add(model);

    //        return model;
    //    }

    //    public IEnumerable<Course_Subject> Filter(Course_Subject model)
    //    {
    //        return _context.Course_Subject.Where(t => model != null && (
    //                                            t.Id == model.Id ||
    //                                            t.CourseConfiguration.CourseId == model.CourseConfiguration.CourseId ||
    //                                            t.SubjectId == model.SubjectId
    //                                                ));
    //    }

    //    public IEnumerable<Course_Subject> GetAll()
    //    {
    //        return _context.Course_Subject;
    //    }

    //    public bool Remove(Guid key)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool Update(Course_Subject model)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
