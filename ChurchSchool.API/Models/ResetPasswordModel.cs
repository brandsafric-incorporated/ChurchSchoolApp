using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchSchool.API.Models
{
    public class ResetPasswordModel
    {
        public string Token { get; set; }
        public string Password { get; set; }
    }
}
