using Shift4Payment.Assignment.DataModelLayer.Models;
using Shift4Payment.Assignment.DataModelLayer.Response;

namespace Shift4Payment.Assignment.SharedLayer.Interface
{
    public interface IUserDatabase
    {
        /// <summary>
        /// authenticate and get user details
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Result<UserModel> LoginUser(string username, string password);
    }
}
