using System;

namespace ChurchSchool.Domain.Entities
{
    public class PersonDocument : Document
    {
        public long PersonId { get; set; }
        public Person Person { get; set; }
    }
}
