using ChurchSchool.Domain.Contracts;
using System;
using System.Net.Mail;

namespace ChurchSchool.Domain.Entities
{
    public class Email : BaseEntity, IValidateObject
    {
        public string Address { get; set; }
        public long PersonId { get; set; }

        public Person Person { get; set; }

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