// See https://aka.ms/new-console-template for more information
using BusinessModels;

namespace ConsoleApp
{
    public enum Menu
    {
        SignUp = 1,
        Login,
        Exit
    }

    public class Program
    {
        
        public static void Main()
        {

            string message;
            string option;
            int value;
            int exit = 1;
            Log logObj = new Log(); 
            Authentications authObj = new Authentications();

            while(true)
            {
                logObj.Write(Literals.choice);
                option = Console.ReadLine();
                value = Convert.ToInt32(option);

                switch(value)
                {
                    case (int)Menu.SignUp:
                        authObj.SignUp();
                        break;
                    case (int)Menu.Login:
                        authObj.Login();
                        break;
                    case (int)Menu.Exit:
                        logObj.Write(Literals.exit);
                        Environment.Exit(exit); 
                        break;
                    default:
                        logObj.Write(Literals.invalidOption);
                        break;
                }

            }
        }
    }
}