using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChurchSchool.Application.Contracts
{
    public interface ICourse
    {
        IEnumerable<Domain.Entities.Course> GetAll();
        IEnumerable<Models.CourseConsolidatedModel> GetConsolidatedData();
        Models.CourseConsolidatedModel GetById(Guid id);
        IEnumerable<Domain.Entities.Course> Filter(string name);
        Domain.Entities.Course Add(Domain.Entities.Course course);
        bool Update(Domain.Entities.Course course);
        bool Remove(Guid id);
    }
}
