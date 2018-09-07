using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Service.Models
{
    public class PasswordRecoveryModel
    {
        public string PersonName { get; set; }
        public string PasswordRecoveryUrl { get; set; }
        public int ExpirationTokenInMinutes { get; set; }
    }
}
