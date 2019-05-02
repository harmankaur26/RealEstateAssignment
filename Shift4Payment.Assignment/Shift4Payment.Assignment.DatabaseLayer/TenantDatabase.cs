using Shift4Payment.Assignment.DatabaseLayer.RealtorEntity;
using Shift4Payment.Assignment.DataModelLayer.Response;
using Shift4Payment.Assignment.SharedLayer.Interface;
using System;

namespace Shift4Payment.Assignment.DatabaseLayer
{
    /// <summary>
    /// Database functions for Tenant operations
    /// </summary>
    public class TenantDatabase : ITenantDatabase
    {
        RealtorEntities dbModel = null;

        public TenantDatabase()
        {
            if (dbModel == null)
            {
                dbModel = new RealtorEntities();
            }
        }

        /// <summary>
        /// save tenant details
        /// </summary>
        /// <param name="tenant"></param>
        /// <returns></returns>
        public Result<int> SaveTenant(DataModelLayer.Models.TenantModel tenant)
        {
            var response = new Result<int>();

            try
            {
                dbModel.spAddTenant
                    (tenant.TenantID,
                    tenant.Firstname,
                    tenant.Lastname,
                    tenant.StartDate,
                    tenant.EndDate,
                    tenant.Amount,
                    tenant.PropertyID,
                    tenant.FileName);

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
