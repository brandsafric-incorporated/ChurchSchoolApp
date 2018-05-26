using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Application.Contracts
{
    public interface ISubject : IBasicOperations<Domain.Entities.Subject>
    {
        IEnumerable<Domain.Entities.Subject> Filter(string name);
    }
}
