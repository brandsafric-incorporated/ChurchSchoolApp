﻿using Microsoft.AspNetCore.Identity;
using System;

namespace ChurchSchool.Domain.Entities.Identity
{
    public class User : IdentityUser
    {
        /// <summary>
        /// Application Person Id related with the inserted login.
        /// </summary>
        public Guid PersonId { get; set; }

        /// <summary>
        /// Indicates the current user is disabled
        /// </summary>
        public bool IsDisabled { get; set; }

        /// <summary>
        /// Token used to validate if the user can reset his password
        /// </summary>
        public string PasswordRecoveryToken { get; set; }

        /// <summary>
        /// the date when the token will expire
        /// </summary>
        public DateTime? PasswordRecoveryRequestedDate { get; set; }
    }

    public class Role : IdentityRole<string>
    { }


    public class UserRole : IdentityUserRole<string>
    { }

    public class UserLogin : IdentityUserLogin<string>
    { }

    public class RoleClaim : IdentityRoleClaim<string>
    { }

    public class UserToken : IdentityUserToken<string>
    { }


}
