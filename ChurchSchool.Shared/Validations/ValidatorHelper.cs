﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Shared.Validations
{
    public static class ValidatorHelper
    {
        public static bool ValidatePassword(string password)
        {
            return !string.IsNullOrEmpty(password) && password.Trim().Length >= 8;
        }
    }
}
