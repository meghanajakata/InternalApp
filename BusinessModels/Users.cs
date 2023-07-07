namespace BusinessModels
{

    public interface IUser
    {
        public string Username { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
    }
    /// <summary>
    /// Represents the user Details variables
    /// </summary>
    public class User : IUser
    {
        public string Username { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }

    }
}