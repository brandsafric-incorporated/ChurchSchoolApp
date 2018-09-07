using Microsoft.AspNetCore.Identity;
using System;

namespace ChurchSchool.Identity.Model
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
}
