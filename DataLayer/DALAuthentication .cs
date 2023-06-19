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
            if (GetSignedUser(userObj) == false)
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
        public string Login(User userObj)
        {
            DataSources dataObject = new DataSources();
            User user = GetLoggedUser(userObj);
            if (userObj == null)
            {
                return Literals.invalidLogin;
            }
            return Literals.loginSuccess;
        }

        /// <summary>
        /// Checks  user if the user is already in Database
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns></returns>
        public bool GetSignedUser(User userObj)
        {

            for (int i = 0; i < DataSources.userDetails.Count; i++)
            {
                if (DataSources.userDetails[i].Username == userObj.Username)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks and returns the user if the user is alreaady Signed In
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User GetLoggedUser(User userObj)
        {
            if (DataSources.userDetails.Count == 0)
            {
                return null;
            }

            for (int i = 0; i < DataSources.userDetails.Count; i++)
            {
                if (DataSources.userDetails[i].Username == userObj.Username && DataSources.userDetails[i].Password == userObj.Password)
                {
                    return DataSources.userDetails[i];
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

    }

   
}