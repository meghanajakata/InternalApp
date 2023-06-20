using System;
using System.Text.RegularExpressions;

namespace BusinessModels
{
    /// <summary>
    /// Represents the string literals
    /// </summary>
    public static class Literals
    {
        public static string choice = "Enter the option to Continue\n1.SignUp\n2.Login\n3.Exit";
        public static string exit = "The application is closing";
        public static string invalidOption = "The option is invalid";
        public static string username = "Enter username ";
        public static string email = "Enter emailId";
        public static string phoneNumber = "Enter MobileNumber";
        public static string password = "Enter password";
        public static string confirmPassword = "Re-enter the password";
        public static string invalidUsername = "***********Please enter username with '_' 'a-z' 'A-Z' ***********";
        public static string invalidEmail = "**********Please enter email ending with @gmail.com***********";
        public static string invalidPassword = "***********Please enter password starting with A-Z and having 'a-z' 'A-Z' '0-9' '_','@','!'***********";
        public static string invalidMobileNumber = "**********Please enter a  10 digit number*********";
        public static string userExists = "***********The user already exists**********";
        public static string invalidLogin = "********Invalid Login please check username and password*********";
        public static string signUpSuccess = "***********The user has successfully Registered*********";
        public static string loginSuccess = "************The user has successfully Logged In*********";
        public static string invalidCast = "***********Do enter numbers*****************";
        public static string forgotPassword = "Forgot Password??\nDo you want to change password\nPress 1 to change password";
        public static string noUsersRegistered = "No users Registered";
        public static string passwordUpdateSuccess = "Password update successful";
        public static string userDoesntExist = "User doesn't exist";
    }
}
