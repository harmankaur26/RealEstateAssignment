using Shift4Payment.Assignment.DatabaseLayer;
using Shift4Payment.Assignment.DataModelLayer.Models;
using Shift4Payment.Assignment.DataModelLayer.Response;

namespace Shift4Payment.Assignment.BusinessLayer
{
    /// <summary>
    /// Business login for user business
    /// </summary>
    public class UserBusiness
    {

        /// <summary>
        /// authenticate user by user name and password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public Result<UserModel> LoginUser(string userName, string password)
        {
            var userDB = new UserDatabase();
            Result<UserModel> result = null;
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                result = userDB.LoginUser(userName, password);
                if (result.Model == null)
                {
                    result.Success = false;
                    result.Message = "Please enter valid user name/password";
                }
            }
            else
            {
                result = new Result<UserModel>();
                result.Message = "Please enter valid user name/password";
                result.Success = false;
                return result;
            }
            return result;
        }
    }
}
