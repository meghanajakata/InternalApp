using BusinessModels;

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
        public string SignUp(User userObj)
        {           
            if (UserExists(userObj) == false)
            {
                AddUser(userObj);
                return Literals.signUpSuccess;
            }
            return Literals.userExists;
        }

        /// <summary>
        /// Checks whether the User is already registered
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string Login(User user)
        {
            User userObj = GetUser(user);
            if (DataSources.userDetails.Count == 0)
            {
                return Literals.noUsersRegistered;
            }
            if (userObj == null)
            {
                return Literals.invalidLogin;
            }
            return Literals.loginSuccess;
        }

        /// <summary>
        /// Represents the forgot password functionality
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns></returns>
        public string ForgotPassword(User userObj)
        {
            if (UserExists(userObj))
            {
                UpdateUser(userObj);
                return Literals.passwordUpdateSuccess;
            }
            return Literals.userDoesntExist;
        }

        /// <summary>
        /// Checks  user if the user is already in Database
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns>
        /// Returns true if user already exists and false if not
        /// </returns>
        public bool UserExists(User userObj)
        {
            User user = DataSources.userDetails.Find(user => user.Username == userObj.Username);

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
        public User GetUser(User userObj)
        {
            User user = DataSources.userDetails.Find(user => user.Username == userObj.Username);
            
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
        public void AddUser(User userObj)
        {
            DataSources.userDetails.Add(userObj);
        }

        /// <summary>
        /// Updates the user password
        /// </summary>
        /// <param name="userObj"></param>
        public void UpdateUser(User userObj)
        {
            User user = DataSources.userDetails.Find(user => user.Username == userObj.Username);

            if (user != null)
            {
                user.Password = userObj.Password;   
            }
        }

    }

   
}