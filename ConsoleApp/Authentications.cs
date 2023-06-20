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
            BALFactory balFacObj = new BALFactory();

            IBAL balObj = balFacObj.GetBALObject();

            // Checks until the user is valid
            while (true)
            {
                Log .Write(Literals.username);
                userObj.Username = Console.ReadLine();
                if (balObj.ValidUsername(userObj.Username))
                {
                    break;
                }
            }

            // Checks until EmailId is valid
            while (true)
            {
                Log.Write(Literals.email);
                userObj.EmailId = Console.ReadLine();

                if (balObj.ValidEmailId(userObj.EmailId))
                {
                    break;
                }
            }

            // Checks until Mobile Number is valid
            while(true)
            {
                Log.Write(Literals.phoneNumber);
                userObj.MobileNumber = Console.ReadLine();

                if(balObj.ValidPhoneNumber(userObj.MobileNumber))
                {
                    break;
                }
            }

            // Checks until the password is valid
            while(true)
            {
                Log.Write(Literals.password);
                userObj.Password = Console.ReadLine();

                if(balObj.ValidPassword(userObj.Password))
                {
                    break;
                }
                Log.Write(Literals.invalidPassword);
            }


            string confirmPassword;

            // Checks until the confirm Password is same as password
            while(true)
            {
                Log.Write(Literals.confirmPassword);
                confirmPassword = Console.ReadLine();

                if(userObj.Password == confirmPassword)
                {
                    break;
                }
            }

            Log.Write(balObj.SignUp(userObj));
        }

        /// <summary>
        /// Represents the User Login
        /// </summary>
        public void Login()
        {
            BALFactory balFactoryObj = new BALFactory();
            IBAL balObj = balFactoryObj.GetBALObject();
            User userObj = new User();

            Log .Write(Literals.username);
            userObj.Username = Console.ReadLine();

            Log.Write(Literals.password);
            userObj.Password = Console.ReadLine();

            string message = balObj.Login(userObj);
            Log.Write(message);

            if(message == Literals.invalidLogin)
            {
                Log.Write(Literals.forgotPassword);
                string option = Console.ReadLine();  
                if(option == "1")
                {
                    ForgotPassword();
                }
            }

        }

        public void ForgotPassword()
        {
            BALFactory balFactoryObj = new BALFactory();
            IBAL balObj = balFactoryObj.GetBALObject();
            User userObj = new User();
            string confirmNewPassword;

            userObj.Username = Console.ReadLine();
            Log.Write(Literals.username);

            // Checks until the password meets the criteria
            while (true)
            {
                Log.Write(Literals.password);
                userObj.Password = Console.ReadLine();

                if (balObj.ValidPassword(userObj.Password))
                {
                    break;
                }
                Log.Write(Literals.invalidPassword);
            }

            // Checks until the confirm Password is same as password
            while (true)
            {
                Log.Write(Literals.confirmPassword);
                confirmNewPassword = Console.ReadLine();

                if (userObj.Password == confirmNewPassword)
                {
                    break;
                }
            }

            Log.Write(balObj.ForgotPassword(userObj));

        }

    }
}
