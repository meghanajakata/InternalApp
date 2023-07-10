//using AutoMapper;
using BModels = BusinessModels;
using DModels = DataModels;
using BusinessModels;

namespace DataLayer
{
    /// <summary>
    /// Represents the Data Layer Authentication
    /// </summary>
    internal class DALAuthentications : IData
    {
        /// <summary>
        /// Checks whether the user is already Registered
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string SignUp(BModels.User userObj)
        {
            if (UserExists(userObj) == false)
            {

                Console.WriteLine("In DALAUTH class");

                //var mapper = MapperConfig.InitializeAutomapper();
                //DModels.User dModeluser = (DModels.User)MapperConfig.MapModel(mapper, userObj);

                //DModels.User dModeluser = new DModels.User();
                //PropertyCopier<BModels.User, DModels.User>.ConvertModel2(userObj, dModeluser);

                DModels.User? dModeluser = ConvertModel(userObj);

                Console.WriteLine(dModeluser.Username + "\t" + dModeluser.EmailId + "\t" + dModeluser.MobileNumber + "\t" + dModeluser.Password);

                AddUser(dModeluser);
                return BModels.Literals.signUpSuccess;
            }
            return BModels.Literals.userExists;
        }

        /// <summary>
        /// Checks whether the User is already registered
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string Login(BModels.User user)
        {
            GetUsers();
            DModels.User userObj = GetUser(user);
            if (DataSources.userDetails.Count == 0)
            {
                return BModels.Literals.noUsersRegistered;
            }
            if (userObj == null)
            {
                return BModels.Literals.invalidLogin;
            }
            return BModels.Literals.loginSuccess;
        }

        /// <summary>
        /// Represents the forgot password functionality
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns></returns>
        public string ForgotPassword(BModels.User userObj)
        {
            if (UserExists(userObj))
            {
                UpdateUser(userObj);
                return BModels.Literals.passwordUpdateSuccess;
            }
            return BModels.Literals.userDoesntExist;
        }

        /// <summary>
        /// Checks  user if the user is already in Database
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns>
        /// Returns true if user already exists and false if not
        /// </returns>
        public bool UserExists(BModels.User userObj)
        {
            DModels.User user = DataSources.userDetails.Find(user => user.Username == userObj.Username);

            if (user == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks and returns the user if the user is alreaady Signed In
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public DModels.User GetUser(BModels.User userObj)
        {
            DModels.User user = DataSources.userDetails.Find(user => user.Username == userObj.Username);

            if (user != null)
            {
                if (user.Password == userObj.Password)
                {
                    return user;
                }
            }
            return null;
        }

        /// <summary>
        /// Adds the user to the database
        /// </summary>
        /// <param name="user"></param>
        public void AddUser(DModels.User userObj)
        {
            DataSources.userDetails.Add(userObj);
        }

        /// <summary>
        /// Updates the user password
        /// </summary>
        /// <param name="userObj"></param>
        public void UpdateUser(BModels.User userObj)
        {
            DModels.User user = DataSources.userDetails.Find(user => user.Username == userObj.Username);

            if (user != null)
            {
                user.Password = userObj.Password;
            }
        }

        public void GetUsers()
        {
            foreach (var item in DataSources.userDetails)
            {
                Console.WriteLine(item.Username + " " + item.Password);
            }
            Console.WriteLine("exiting getusers");
        }

        //public dynamic? ConvertModel(dynamic getModel)
        //{
        //    dynamic setModel;
        //    string modelType = Convert.ToString(getModel.GetType().Name);

        //    //if (getModel.GetType().Name == typeof(DModels.User))
        //    if(modelType == Convert.ToString(typeof(DModels.User)))
        //    {
        //        setModel = new BModels.User();

        //    }

        //    else
        //    {
        //        setModel = new DModels.User();

        //    }

        //    setModel.Username = getModel.Username;
        //    setModel.EmailId = getModel.EmailId;
        //    setModel.MobileNumber = getModel.MobileNumber;
        //    setModel.Password = getModel.Password;

        //    return setModel;

        //}


        public dynamic ConvertModel(IUser getModel)
        {
            dynamic setModel;

            if (getModel is BModels.User)
            {
                setModel = (DModels.User)getModel;
            }

            else
            {
                setModel = (BModels.User)getModel;

            }

            return setModel;
        }

    }

    //public class MapperConfig
    //{
    //    public static Mapper InitializeAutomapper()
    //    {
    //        //Provide all the Mapping Configuration
    //        var config = new MapperConfiguration(cfg =>
    //        {
    //            //Configuring Employee and EmployeeDTO
    //            cfg.CreateMap<BModels.User,DModels.User>();
    //            //Any Other Mapping Configuration ....
    //        });
    //        //Create an Instance of Mapper and return that Instance
    //        var mapper = new Mapper(config);
    //        return mapper;
    //    }

    //    public static Object MapModel(dynamic mapper,Object getObj)
    //    {
    //        Object setObj;
    //        if (getObj.GetType() == typeof(BModels.User))
    //        {
    //            setObj = mapper.Map<DModels.User>(getObj);

    //        }
    //        else
    //        {
    //            setObj = mapper.Mapper<BModels.User>(getObj);
    //        }
    //        return setObj;
    //    }
    //}

    /// <summary>
    /// Represents Property copying using Reflection
    /// </summary>
    /// <typeparam name="Tobj1"></typeparam>
    /// <typeparam name="Tobj2"></typeparam>
    public class PropertyCopier<Tobj1, Tobj2> where Tobj1 : class where Tobj2 : class
    {
        public static void ConvertModel2(Tobj1 getModel, Tobj2 setModel)
        {
            var getModelProperties = getModel.GetType().GetProperties();
            var setModelProperties = setModel.GetType().GetProperties();

            foreach (var getModelProperty in getModelProperties)
            {
                foreach (var setModelProperty in setModelProperties)
                {
                    if (getModelProperty.Name == setModelProperty.Name && getModelProperty.PropertyType == setModelProperty.PropertyType)
                    {
                        setModelProperty.SetValue(setModel, getModelProperty.GetValue(getModel));
                        break;
                    }
                }
            }
        }
    }



}