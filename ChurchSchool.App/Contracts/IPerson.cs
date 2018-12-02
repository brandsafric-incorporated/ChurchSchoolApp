using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Application.Contracts
{
    public interface IPerson : IBasicOperations<Domain.Entities.Person>
    {
        bool CheckIfExists(Domain.Entities.Person person);
        Domain.Entities.Person Filter(Domain.Entities.Person personParameters);
        Domain.Entities.Person FilterByCPF(long cpf);
    }
}
