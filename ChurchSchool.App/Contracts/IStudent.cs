using ChurchSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChurchSchool.Application.Contracts
{
    public interface IStudent : IBasicOperations<Domain.Entities.Student>
    {

    }
}
