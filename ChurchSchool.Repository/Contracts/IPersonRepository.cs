﻿using ChurchSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Repository.Contracts
{
    public interface IPersonRepository : IRepository<Person>
    {
        Domain.Entities.Person GetByCPF(string cpfNumber);
    }
}
