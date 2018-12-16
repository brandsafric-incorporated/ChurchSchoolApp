﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChurchSchool.Application.Contracts
{
    public interface ICourse
    {
        IEnumerable<Domain.Entities.Course> GetAll();        
        Domain.Entities.Course GetById(long id);        
        Domain.Entities.Course Add(Domain.Entities.Course course);
        bool Update(Domain.Entities.Course course);
        bool Remove(long id);


        IEnumerable<Domain.Entities.Course> Filter(string name);
        IEnumerable<Domain.Entities.Course> Filter(Domain.Entities.Course course);
    }
}
