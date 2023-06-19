namespace BusinessLayer
{
    /// <summary>
    /// Represents factory pattern for Business Layer
    /// </summary>
    public class BALFactory
    {
        /// <summary>
        /// Returns the object for BALAuthentication
        /// </summary>
        /// <returns></returns>
        public IBAL GetBALObject()
        {
            return new BALAuthentications();
        }

        //public IBALValidations GetBALValidations()
        //{
        //    return new BALValidations();
        //}
    }
}
