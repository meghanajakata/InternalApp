using BusinessModels;
using DataLayer;

namespace BusinessLayer
{
    /// <summary>
    /// Represents the authentication in business layer
    /// </summary>
    internal class BALAuthentications : IBAL
    {
        /// <summary>
        /// Represents the Signup for the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string SignUp(User userObj)
        {
            DataFactory dataFactoryObj = new DataFactory();
            IData dataAuthObj = dataFactoryObj.GetAuthenticationsObject();
            return (dataAuthObj.SignUp(userObj));
        }

        /// <summary>
        /// Represents the Login for the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string Login(User userObj)
        {
            DataFactory dataFactoryObj= new DataFactory();
            IData dataAuthObj= dataFactoryObj.GetAuthenticationsObject();
            return(dataAuthObj.Login(userObj));
        }

        /// <summary>
        /// Represents the forgot password functionality for the user
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns>
        /// Returns a string specifying status
        /// </returns>
        public string ForgotPassword(User userObj)
        {
            DataFactory dataFactoryObj= new DataFactory();
            IData dataAuthObj = dataFactoryObj.GetAuthenticationsObject();
            return(dataAuthObj.ForgotPassword(userObj));
        }

        /// <summary>
        /// Validates whether the given username matches the criteria
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool ValidUsername(string username)
        {
            BALValidations balValObj = new BALValidations();
            return balValObj.IsValidUsername(username);
        }

        /// <summary>
        /// Validates whether the given emailId meets the criteria
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns></returns>
        public bool ValidEmailId(string emailId)
        {
            BALValidations balValObj = new BALValidations();
            return balValObj.IsValidEmail(emailId);
        }

        /// <summary>
        /// Validates whether the given mobile number meets the criteria
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public bool ValidPhoneNumber(string phoneNumber)
        {
            BALValidations balValObj = new BALValidations();
            return balValObj.IsValidMobilenumber(phoneNumber);
        }

        /// <summary>
        /// Validates whether the given password meets the criteria
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ValidPassword(string password)
        {
            BALValidations balValObj = new BALValidations();
            return balValObj.IsValidPassword(password);
        }
    }
}
