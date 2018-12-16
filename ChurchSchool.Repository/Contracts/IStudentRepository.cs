﻿using System;
using System.Collections.Generic;
using ChurchSchool.Domain.Entities;

namespace ChurchSchool.Repository.Contracts
{
    public interface IStudentRepository : IRepository<Student>
    {
        bool VerifyStudentAlreadyEnrolled(string cpf, long courseId);
        long GetTotalActiveStudents();
        IEnumerable<Student> GetPendingEnrollments();
    }
}
