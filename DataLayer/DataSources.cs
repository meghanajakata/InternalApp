using BusinessModels;
namespace DataLayer
{
    
    /// <summary>
    /// Represents the Data Operations 
    /// </summary>
    internal class DataSources
    {
        /// <summary>
        /// Data structure to store database
        /// </summary>
        internal static List<User> userDetails = new List<User>();


        /// <summary>
        /// Adds the user to the database
        /// </summary>
        /// <param name="user"></param>
        public void AddUser(User userObj)
        {
            userDetails.Add(userObj);
        }
    }
}
