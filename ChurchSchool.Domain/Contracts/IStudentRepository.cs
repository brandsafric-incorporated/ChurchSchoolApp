﻿using System;
using System.Collections.Generic;
using ChurchSchool.Domain.Entities;

namespace ChurchSchool.Domain.Contracts
{
    public interface IStudentRepository : IRepository<Student>
    {
        bool VerifyStudentAlreadyEnrolled(string cpf, Guid courseId);        
    }
}
