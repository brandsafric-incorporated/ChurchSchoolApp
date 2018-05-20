using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Shared.Exceptions
{
    public class PersonDocumentException : Exception
    {
        public PersonDocumentException(string message) : base(message)
        {
        }
    }
}
