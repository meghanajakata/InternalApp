using BusinessModels;

namespace BusinessLayer
{
    /// <summary>
    /// Represents the interface for Business Layer
    /// </summary>
    public interface IBAL
    {
        public string SignUp(User user);
        public string Login(User user);
    }

    public interface IBALValidations
    {
        public bool IsValidUsername(string username);
        public bool IsValidPassword(string password);
        public bool IsValidEmail(string email);
        public bool IsValidMobilenumber(string mobileNumber);
    }
}
