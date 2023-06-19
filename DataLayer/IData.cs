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
        public bool GetSignedUser(User userObj);
        public User GetLoggedUser(User userObj);

    }
}
