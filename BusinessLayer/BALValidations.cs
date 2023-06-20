using System.Text.RegularExpressions;

namespace BusinessLayer
{
    /// <summary>
    /// Represents the validations of business layer
    /// </summary>
    internal class BALValidations 
    {
        /// <summary>
        /// Checks whether the username is valid
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool IsValidUsername(string username)
        {
            if(Regex.IsMatch(username, @"(^[a-zA-Z_]{3,12}$)"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks whether the password is valid
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsValidPassword(string password)
        {
            if (Regex.IsMatch(password, @"(^[A-Z])[a-zA-Z0-9_!@]{8,20}$"))
            {
                return true;
            }
            return false;

        }

        /// <summary>
        /// Checks if the email is valid
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsValidEmail(string email)
        {
            if (email == null || Regex.IsMatch(email,"^[a-z]{1,}?@gmail.com$") == false)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks whether MobileNumber is valid
        /// </summary>
        /// <param name="mobileNumber"></param>
        /// <returns></returns>
        public bool IsValidMobilenumber(string mobileNumber)
        {
            if(Regex.IsMatch(mobileNumber,"^[0-9]{10}$"))
            {
                return true;
            }
            return false;
        }
    }
}