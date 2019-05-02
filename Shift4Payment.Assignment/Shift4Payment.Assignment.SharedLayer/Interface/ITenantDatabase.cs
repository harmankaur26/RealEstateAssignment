using Shift4Payment.Assignment.DataModelLayer.Models;
using Shift4Payment.Assignment.DataModelLayer.Response;

namespace Shift4Payment.Assignment.SharedLayer.Interface
{
   public interface ITenantDatabase
    {
        /// <summary>
        /// save tenant details
        /// </summary>
        /// <param name="tenant"></param>
        /// <returns></returns>
        Result<int> SaveTenant(TenantModel tenant);

    }
}
