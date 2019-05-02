using Shift4Payment.Assignment.DatabaseLayer;
using Shift4Payment.Assignment.DataModelLayer.Models;
using Shift4Payment.Assignment.DataModelLayer.Response;

namespace Shift4Payment.Assignment.BusinessLayer
{
    /// <summary>
    /// defines the business logic for saving tenant details
    /// </summary>
    public class TenantBusiness
    {
        /// <summary>
        /// save tenant details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Result<int> SaveTenant(TenantModel model)
        {
            var tenantDB = new TenantDatabase();
            return tenantDB.SaveTenant(model);
        }
    }
}
