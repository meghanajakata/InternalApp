using AutoMapper;
using BusinessModels;
using DataModels;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using BModels = BusinessModels;
using DModels = DataModels;

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
                var mapper = MapperConfig.InitializeAutomapper();
                //DModels.User dModeluser = (DModels.User)MapperConfig.MapModel(mapper,userObj);
                DModels.User dModeluser = new DModels.User();
                PropertyCopier.ConvertModel2(mapper, dModeluser);
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

        //public dynamic? ConvertModel(dynamic getModel)
        //{
        //    dynamic setModel;
        //    if (getModel.GetType().Name == typeof(DModels.User))
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

        
        public dynamic CovertModel(IUser getModel)
        {
            dynamic setModel;

            if(getModel is BModels.User)
            {
                setModel = (DModels.User)getModel;
            }

            else
            {
                setModel = (BModels.User)getModel;

            }
            
            return setModel;
        }

        //public dynamic ConvertModel1<T>(T setModel)
        //{

        //}



    }

    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                //Configuring Employee and EmployeeDTO
                cfg.CreateMap<BModels.User,DModels.User>();
                //Any Other Mapping Configuration ....
            });
            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }

        public static Object MapModel(dynamic mapper,Object getObj)
        {
            Object setObj;
            if (getObj.GetType() == typeof(BModels.User))
            {
                setObj = mapper.Map<DModels.User>(getObj);

            }
            else
            {
                setObj = mapper.Mapper<BModels.User>(getObj);
            }
            return setObj;
        }
    }

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
                    if (getModelProperty.Name == setModelProperty.Name && getModelProperty == setModelProperty.PropertyType)
                    {
                        setModelProperty.SetValue(setModel, getModelProperty.GetValue(getModel));
                        break;
                    }
                }
            }
        }
    }



}