using BusinessModels;

namespace DataLayer
{
    /// <summary>
    /// Represents the interface for Data Acess Layer
    /// </summary>
    public interface IData
    {
        public string SignUp(User userObj);
        public string Login(User userObj);
        public string ForgotPassword(User userObj);
        public bool UserExists(User userObj);
        public User GetUser(User userObj);

    }
}
