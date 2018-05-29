using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Application.Contracts
{
    public interface IPerson : IBasicOperations<Domain.Entities.Person>
    {
        bool CheckIfExists(Domain.Entities.Person person);
    }
}
