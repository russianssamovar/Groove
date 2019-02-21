using System;
using CommonModels.Identity;

namespace Groove.Domain
{
    public static class RegistrationModelChecker
    {
        public static void Check(ReistrationModel reg)
        {
            if (reg.Password != reg.ConfirmPassword)
            {
                throw new ArgumentException("Password and Confirm Password not equal");
            }

            if (reg.Email != reg.ConfirmEmail)
            {
                throw new ArgumentException("Email and Confirm Email not equal");
            }

            
            if (!(reg.Password.Length < 7))
            {
                throw new ArgumentException("Please, insert more strong password");
            }

            if (!reg.Email.Contains('@'))
            {
                throw new ArgumentException("Thats not email");
            }
        }
    }
}