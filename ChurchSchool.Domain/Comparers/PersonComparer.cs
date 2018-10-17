using ChurchSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Domain.Comparers
{
    public class PersontComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return x?.Id == y?.Id;
        }

        public int GetHashCode(Person obj)
        {
            return 0;
        }
    }
}
