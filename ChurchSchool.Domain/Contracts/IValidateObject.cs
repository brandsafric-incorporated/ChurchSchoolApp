using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Domain.Contracts
{
    public interface IValidateObject
    {
        bool IsValid();
    }
}
