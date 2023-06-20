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
        public string ForgotPassword(User userObj);
        public bool ValidUsername(string username);
        public bool ValidEmailId(string emailId);
        public bool ValidPhoneNumber(string phoneNumber);
        public bool ValidPassword(string password);
    }
}
