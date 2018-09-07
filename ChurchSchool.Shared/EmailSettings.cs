using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Shared
{
    public class EmailSettings
    {
        public string Host { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public bool IsSecureConnection { get; set; }
    }
}
