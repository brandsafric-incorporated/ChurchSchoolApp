﻿using System;

namespace ChurchSchool.Domain.Entities
{
    public class PersonDocument : Document
    {
        public Guid PersonId { get; set; }

        public bool IsRequired { get; set; }

        public Person Person { get; set; }
    }
}
