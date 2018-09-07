using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Shared
{
    public class ApplicationSettings
    {
        public ApplicationSettings()
        {

        }

        public string SecretKey { get; set; }
        public EmailSettings EmailSettings { get; set; }
        public RecoverPasswordSettings RecoverPasswordSettings { get; set; }
        public string ApplicationBaseUri { get; set; }
    }

    public class RecoverPasswordSettings
    {
        public int TokenExpireTimeInMinutes { get; set; }
    }
}
