using BusinessLayer;
using BusinessModels;

namespace ConsoleApp
{
    /// <summary>
    /// Represents the Authentication for Login and SignUp
    /// </summary>
    public class Authentications
    {
        /// <summary>
        /// Represents the User SignUp
        /// </summary>
        public void SignUp()
        {
            User userObj = new User();
            BALValidations balValObj = new BALValidations();
            BALFactory balFacObj = new BALFactory();

            IBAL balObj = balFacObj.GetBALObject();

            Log logObj = new Log();

            logObj.Write(Literals.username);
            userObj.Username = Console.ReadLine();

            // Checks until the user is valid
            while (!balValObj.IsValidUsername(userObj.Username))
            {
                logObj.Write(Literals.invalidUsername);
                userObj.Username = Console.ReadLine();
            }

            logObj.Write(Literals.email);
            userObj.EmailId = Console.ReadLine();

            // Checks until EmailId is valid
            while (balValObj.IsValidEmail(userObj.EmailId) == false)
            {
                logObj.Write(Literals.invalidEmail);
                userObj.EmailId = Console.ReadLine();
            }

            logObj.Write(Literals.phoneNumber);
            userObj.MobileNumber = Console.ReadLine();

            // Checks until Mobile Number is valid
            while (balValObj.IsValidMobilenumber(userObj.MobileNumber) == false)
            {
                logObj.Write(Literals.invalidMobileNumber);
                userObj.MobileNumber = Console.ReadLine();
            }

            logObj.Write(Literals.password);
            userObj.Password = Console.ReadLine();

            // Checks until the password is valid
            while (balValObj.IsValidPassword(userObj.Password) == false)
            {
                logObj.Write(Literals.invalidPassword);
                userObj.Password = Console.ReadLine();
            }

            logObj.Write(Literals.confirmPassword);
            string confirmPassword = Console.ReadLine();

            // Checks until the confirm Password is same as password
            while (userObj.Password != confirmPassword)
            {
                logObj.Write(Literals.confirmPassword);
                confirmPassword = Console.ReadLine();
            }

            logObj.Write(balObj.SignUp(userObj));
        }

        /// <summary>
        /// Represents the User Login
        /// </summary>
        public void Login()
        {
            Log logObj = new Log();
            BALFactory balFactoryObject = new BALFactory();
            IBAL balObj = balFactoryObject.GetBALObject();

            User userObj = new User();

            logObj.Write(Literals.username);
            userObj.Username = Console.ReadLine();

            logObj.Write(Literals.password);
            userObj.Password = Console.ReadLine();

            logObj.Write(balObj.Login(userObj));

        }

    }
}
