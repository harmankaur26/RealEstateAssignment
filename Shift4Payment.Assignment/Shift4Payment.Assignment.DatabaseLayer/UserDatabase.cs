using Shift4Payment.Assignment.DatabaseLayer.RealtorEntity;
using Shift4Payment.Assignment.DataModelLayer.Models;
using Shift4Payment.Assignment.DataModelLayer.Response;
using Shift4Payment.Assignment.SharedLayer.Interface;
using System;
using System.Linq;

namespace Shift4Payment.Assignment.DatabaseLayer
{
    /// <summary>
    /// database function for user authentication
    /// </summary>
    public class UserDatabase : IUserDatabase
    {
        RealtorEntities dbModel = null;

        public UserDatabase()
        {
            if (dbModel == null)
            {
                dbModel = new RealtorEntities();
            }
        }
        /// <summary>
        /// authenticate and get user details
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Result<DataModelLayer.Models.UserModel> LoginUser(string username, string password)
        {
            var response = new Result<UserModel>();
            try
            {
                var user = (from u in dbModel.spLoginUser(username, password)
                            select new UserModel
                            {
                                Username = u.Username,
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                Role = u.Role,
                                UserID = u.UserID
                            }).SingleOrDefault();
                response.Model = user;
                response.Success = true;
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }
    }
}
