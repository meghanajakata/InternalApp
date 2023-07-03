using BModels = BusinessModels;
using DModels = DataModels;

namespace DataLayer
{
    /// <summary>
    /// Represents the interface for Data Acess Layer
    /// </summary>
    public interface IData
    {
        public string SignUp(BModels.User userObj);
        public string Login(BModels.User userObj);
        public string ForgotPassword(BModels.User userObj);
        public bool UserExists(BModels.User userObj);
        public DModels.User GetUser(BModels.User userObj);

    }
}
