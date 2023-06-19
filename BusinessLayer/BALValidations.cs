using System.Text.RegularExpressions;

namespace BusinessLayer
{
    /// <summary>
    /// Represents the validations of business layer
    /// </summary>
    public class BALValidations
    {
        /// <summary>
        /// Checks whether the username is valid
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool IsValidUsername(string username)
        {
            if(StartsWith(username) == false)
            {
                return false;
            }
            if(Contains(username) == false)
            {
                return false;
            }
            return true;    
        }

        /// <summary>
        /// Checks whether the password is valid
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsValidPassword(string password)
        {
            if (password == null || password.Length < 8 || Regex.IsMatch(password, "[A-Za-z0-9]") == false )
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if the email is valid
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsValidEmail(string email)
        {
            if (email == null || Regex.IsMatch(email,"@gmail.com$") == false)
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
            if(!Regex.IsMatch(mobileNumber,"^[6 - 9]\\d{ 9}$"))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks whether the string startswith certain value
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool StartsWith(string name)
        {
            if (name[0] == '_' || (name[0] >= 'a' && name[0] <= 'z') || (name[0] >= 'A' && name[0] <= 'Z'))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks whether the name contains required values
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public  bool Contains(string name)
        {
            if (name.Length == 1) return true;
            for (int i = 1; i < name.Length; i++)
            {
                if (!char.IsLetterOrDigit(name[i])) return false;
            }
            return true;
        }
    }
}