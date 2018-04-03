using ChurchSchool.Domain.Contracts;
using System;
using System.Net.Mail;

namespace ChurchSchool.Domain.Entities
{
    public class Email : IValidateObject
    {
        public string Address { get; set; }

        public bool IsValid()
        {
            try
            {
                var mailAddress = new MailAddress(Address, string.Empty);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}