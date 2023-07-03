namespace BusinessModels
{
    /// <summary>
    /// Represents the user Details variables
    /// </summary>
    public class User
    {
        public string Username { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }

        //public static explicit operator DModels.User(BusinessModels.User user)
        //{
        //    DModels.User dUserObj = new DModels.User();
        //    dUserObj.Username = user.Username;
        //    dUserObj.EmailId = user.EmailId;
        //    dUserObj.MobileNumber = user.MobileNumber;
        //    dUserObj.Password = user.Password;

        //    return dUserObj;
        //}

    }
}