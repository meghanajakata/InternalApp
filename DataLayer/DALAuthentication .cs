using BusinessModels;
using BModels = BusinessModels;
using DModels = DataModels;

namespace DataLayer
{
    /// <summary>
    /// Represents the Data Layer Authentication
    /// </summary>
    internal class DALAuthentications : IData
    {   
        /// <summary>
        /// Checks whether the user is already Registered
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string SignUp(BModels.User userObj)
        {           
            if (UserExists(userObj) == false)
            {
                DModels.User dModeluser = ConvertToDataModel(userObj);  
                AddUser(dModeluser);
                return BModels.Literals.signUpSuccess;
            }
            return BModels.Literals.userExists;
        }

        /// <summary>
        /// Checks whether the User is already registered
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string Login(BModels.User user)
        {
            DModels.User userObj = GetUser(user);
            if (DataSources.userDetails.Count == 0)
            {
                return BModels.Literals.noUsersRegistered;
            }
            if (userObj == null)
            {
                return BModels.Literals.invalidLogin;
            }
            return BModels.Literals.loginSuccess;
        }

        /// <summary>
        /// Represents the forgot password functionality
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns></returns>
        public string ForgotPassword(BModels.User userObj)
        {
            if (UserExists(userObj))
            {
                UpdateUser(userObj);
                return BModels.Literals.passwordUpdateSuccess;
            }
            return BModels.Literals.userDoesntExist;
        }

        /// <summary>
        /// Checks  user if the user is already in Database
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns>
        /// Returns true if user already exists and false if not
        /// </returns>
        public bool UserExists(BModels.User userObj)
        {
            DModels.User user = DataSources.userDetails.Find(user => user.Username == userObj.Username);

            if (user == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks and returns the user if the user is alreaady Signed In
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public DModels.User GetUser(BModels.User userObj)
        {
            DModels.User user = DataSources.userDetails.Find(user => user.Username == userObj.Username);
            
            if(user != null)
            {
                if(user.Password == userObj.Password)
                {
                    return user;
                }
            }
            return null;
        }

        /// <summary>
        /// Adds the user to the database
        /// </summary>
        /// <param name="user"></param>
        public void AddUser(DModels.User userObj)
        {
            DataSources.userDetails.Add(userObj);
        }

        /// <summary>
        /// Updates the user password
        /// </summary>
        /// <param name="userObj"></param>
        public void UpdateUser(BModels.User userObj)
        {
            DModels.User user = DataSources.userDetails.Find(user => user.Username == userObj.Username);

            if (user != null)
            {
                user.Password = userObj.Password;   
            }
        }

        public DModels.User ConvertToDataModel(BModels.User user)
        {
            DModels.User dUserObj = new DModels.User();
            dUserObj.Username = user.Username;
            dUserObj.EmailId = user.EmailId;
            dUserObj.MobileNumber = user.MobileNumber;
            dUserObj.Password = user.Password;

            return dUserObj;
        }

    }

   
}