using BusinessModels;
using DataLayer;

namespace BusinessLayer
{
    /// <summary>
    /// Represents the authentication in business layer
    /// </summary>
    internal class BALAuthentications : IBAL
    {
        /// <summary>
        /// Represents the Signup for the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string SignUp(User userObj)
        {
            DataFactory dataFactoryObj = new DataFactory();
            IData dataAuthObject = dataFactoryObj.GetAuthenticationsObject();
            return (dataAuthObject.SignUp(userObj));
        }

        /// <summary>
        /// Represents the Login for the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string Login(User userObj)
        {
            DataFactory dataFactoryObject = new DataFactory();
            IData dataAuthObject = dataFactoryObject.GetAuthenticationsObject();
            return(dataAuthObject.Login(userObj));
        }
    }
}
