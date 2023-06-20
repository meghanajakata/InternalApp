// See https://aka.ms/new-console-template for more information
using BusinessModels;

namespace ConsoleApp
{

    public class Program
    {

        public static void Main()
        {

            string message;
            string option;
            int value ;
            int exit = 1;
            Authentications authObj = new Authentications();
            while (true)
            {
                Log.Write(Literals.choice);
                option = Console.ReadLine();

                try
                {
                    value = Convert.ToInt32(option);
                    switch (value)
                    {
                        case (int)Menu.SignUp:
                            authObj.SignUp();
                            break;
                        case (int)Menu.Login:
                            authObj.Login();
                            break;
                        case (int)Menu.Exit:
                            Log.Write(Literals.exit);
                            Environment.Exit(0);
                            break;
                        default:
                            Log.Write(Literals.invalidOption);
                            break;
                    }
                }

                catch (Exception ex)
                {
                    Log.Write(Literals.invalidCast);
                }
            }
        }
    }
}