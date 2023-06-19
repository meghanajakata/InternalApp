namespace DataLayer
{
    /// <summary>
    /// Represents the Factory patteren for DataLayer
    /// </summary>
    public class DataFactory
    {
        /// <summary>
        /// Returns the object of DALAuthentication
        /// </summary>
        /// <returns></returns>
        public IData GetAuthenticationsObject() 
        {
            return new DALAuthentications();
        }
    }
}
