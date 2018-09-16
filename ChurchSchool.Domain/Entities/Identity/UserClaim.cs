using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Domain.Entities.Identity
{
    public class UserClaim : IdentityUserClaim<string>
    {
        /// <summary>
        /// Value to be show
        /// </summary>
        public string DisplayValue { get; set; }
    }
}
